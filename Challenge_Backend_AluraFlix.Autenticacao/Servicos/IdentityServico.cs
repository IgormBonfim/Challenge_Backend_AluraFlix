using Challenge_Backend_AluraFlix.Autenticacao.Configuracoes;
using Challenge_Backend_AluraFlix.Autenticacao.Servicos.Interfaces;
using Challenge_Backend_AluraFlix.DataTransfer.Usuarios.Requests;
using Challenge_Backend_AluraFlix.DataTransfer.Usuarios.Responses;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Web;

namespace Challenge_Backend_AluraFlix.Autenticacao.Servicos
{
    public class IdentityServico : IIdentityServico
    {
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;
        private readonly JwtOptions jwtOptions;

        public IdentityServico(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, IOptions<JwtOptions> jwtOptions)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.jwtOptions = jwtOptions.Value;
        }

        public async Task<UsuarioAtivarResponse> Ativar(UsuarioAtivarRequest usuarioAtivarRequest)
        {
            var identityUser = userManager.Users.FirstOrDefault(u => u.Id == usuarioAtivarRequest.IdUsuario);

            if (identityUser == null)
                throw new Exception("Usuario não encontrado");

            var identityResult = await userManager.ConfirmEmailAsync(identityUser, usuarioAtivarRequest.TokenAtivacao);

            var usuarioAtivarResponse = new UsuarioAtivarResponse(identityResult.Succeeded);

            if (!identityResult.Succeeded && identityResult.Errors.Count() > 0)
                usuarioAtivarResponse.AdicionarErros(identityResult.Errors.Select(r => r.Description));

            return usuarioAtivarResponse;   
        }

        public async Task<UsuarioCadastroResponse> CadastrarUsuario(UsuarioCadastroRequest usuarioCadastro)
        {
            var identityUser = new IdentityUser
            {
                UserName = usuarioCadastro.Email,
                Email = usuarioCadastro.Email,
            };

            var result = await userManager.CreateAsync(identityUser, usuarioCadastro.Senha);

            UsuarioCadastroResponse usuarioCadastroResponse = new UsuarioCadastroResponse(result.Succeeded);

            if (result.Succeeded)
            {
                usuarioCadastroResponse.IdUsuario = RecuperarUsuarioPorEmail(identityUser.Email).Id;

                var tokenAtivacao = userManager.GenerateEmailConfirmationTokenAsync(identityUser).Result;
                usuarioCadastroResponse.TokenEmail = HttpUtility.UrlEncode(tokenAtivacao);
                await userManager.SetLockoutEnabledAsync(identityUser, false);
            }

            if (!result.Succeeded && result.Errors.Count() > 0)
                usuarioCadastroResponse.AdicionarErros(result.Errors.Select(r => r.Description));

            return usuarioCadastroResponse;
        }

        public async Task<UsuarioLoginResponse> Login(UsuarioLoginRequest usuarioLoginRequest)
        {
            var result = await signInManager.PasswordSignInAsync(usuarioLoginRequest.Email, usuarioLoginRequest.Senha, false, true);
            if (result.Succeeded)
                return await GerarToken(usuarioLoginRequest.Email);

            var usuarioLoginResponse = new UsuarioLoginResponse(result.Succeeded);
            if (!result.Succeeded)
            {
                if (result.IsLockedOut)
                    usuarioLoginResponse.AdicionarErro("Essa conta está bloqueada");
                else if (result.IsNotAllowed)
                    usuarioLoginResponse.AdicionarErro("Essa conta não tem permissão para fazer login");
                else if (result.RequiresTwoFactor)
                    usuarioLoginResponse.AdicionarErro("É necessário confirmar o login no seu segundo fator de autenticação");
                else
                    usuarioLoginResponse.AdicionarErro("Usuário ou senha estão incorretos");
            }

            return usuarioLoginResponse;
        }

        public UsuarioLogoutResponse Logout()
        {
            var result = signInManager.SignOutAsync();

            UsuarioLogoutResponse usuarioLogoutResponse = new UsuarioLogoutResponse(result.IsCompletedSuccessfully);
            return usuarioLogoutResponse;
        }

        public async Task<UsuarioAlterarSenhaResponse> RecuperarSenha(UsuarioAlterarSenhaRequest usuarioAlterarSenhaRequest)
        {
            IdentityUser? identityUser = RecuperarUsuarioPorEmail(usuarioAlterarSenhaRequest.Email);

            UsuarioAlterarSenhaResponse usuarioAlterarSenhaResponse = new UsuarioAlterarSenhaResponse(identityUser != null);

            if (identityUser != null)
            {
                string codigo = await userManager.GeneratePasswordResetTokenAsync(identityUser);
                usuarioAlterarSenhaResponse.TokenAlteracao = codigo;
            }

            return usuarioAlterarSenhaResponse;
        }

        private async Task<UsuarioLoginResponse> GerarToken(string email)
        {
            var user = await userManager.FindByEmailAsync(email);
            var tokenClaims = await ObterClaims(user);

            var dataExpiracao = DateTime.Now.AddSeconds(jwtOptions.Expiration);

            var jwt = new JwtSecurityToken(
                issuer: jwtOptions.Issuer,
                audience: jwtOptions.Audience,
                claims: tokenClaims,
                notBefore: DateTime.Now,
                expires: dataExpiracao,
                signingCredentials: jwtOptions.SigningCredentials);

            var token = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new UsuarioLoginResponse
            (
                sucesso: true,
                token: token,
                dataExpiracao: dataExpiracao
            );
        }

        public async Task<UsuarioRedefinirResponse> RedefinirSenha(UsuarioRedefinirRequest usuarioRedefinirRequest)
        {
            IdentityUser identityUser = RecuperarUsuarioPorEmail(usuarioRedefinirRequest.Email);

            if (identityUser == null)
            {
                UsuarioRedefinirResponse usuarioResponse = new UsuarioRedefinirResponse(false);
                usuarioResponse.AdicionarErro("Este Email não está cadastrado");
                return usuarioResponse;
            }

            var result = await userManager.ResetPasswordAsync(identityUser, usuarioRedefinirRequest.TokenSenha, usuarioRedefinirRequest.Senha);

            UsuarioRedefinirResponse usuarioRedefinirResponse = new UsuarioRedefinirResponse(result.Succeeded);

            if (!result.Succeeded)
            {
                usuarioRedefinirResponse.AdicionarErros(result.Errors.Select(error => error.Description));
            }

            return usuarioRedefinirResponse;
        }

        private IdentityUser RecuperarUsuarioPorEmail(string email)
        {
            return userManager.Users.FirstOrDefault(u => u.NormalizedEmail == email.ToUpper());
        }

        private async Task<IList<Claim>> ObterClaims(IdentityUser user)
        {
            var claims = await userManager.GetClaimsAsync(user);
            var roles = await userManager.GetRolesAsync(user);

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
            claims.Add(new Claim("codigoUsuario", user.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, DateTime.Now.ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()));

            foreach (var role in roles)
                claims.Add(new Claim("role", role));

            return claims;
        }
    }
}
