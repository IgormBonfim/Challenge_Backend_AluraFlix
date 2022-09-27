using Challenge_Backend_AluraFlix.Dominio.Usuario.Servicos.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Backend_AluraFlix.Infra.Usuario.Autenticacao
{
    public class GeradorTokenJwt : IGeradorTokenJwt
    {
        public string GerarToken(Guid idUsuario, string nomeUsuario, string sobrenomeUsuario)
        {
            var siginingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes("super-secret-key")),
                SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, idUsuario.ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName, nomeUsuario),
                new Claim(JwtRegisteredClaimNames.FamilyName, sobrenomeUsuario),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var securityToken = new JwtSecurityToken(
                issuer: "Igor Bonfim",
                expires: DateTime.UtcNow.AddDays(2),
                claims: claims,
                signingCredentials: siginingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}
