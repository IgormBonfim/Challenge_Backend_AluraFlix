using Challenge_Backend_AluraFlix.Aplicacao.Usuarios.Servicos.Interfaces;
using Challenge_Backend_AluraFlix.DataTransfer.Usuarios.Requests;
using Challenge_Backend_AluraFlix.DataTransfer.Usuarios.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Challenge_Backend_AluraFlix.API.Controllers.Usuarios
{
    [AllowAnonymous]
    [Route("api/usuarios")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuariosAppServico usuarioAppServico;

        public UsuariosController(IUsuariosAppServico usuarioAppServico)
        {
            this.usuarioAppServico = usuarioAppServico;
        }

        [HttpPost("cadastrar")]
        public ActionResult<UsuarioCadastroResponse> Cadastrar([FromBody] UsuarioCadastroRequest usuarioCadastro)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var retorno = usuarioAppServico.Cadastrar(usuarioCadastro);
            if (retorno.Sucesso)
                return Ok(retorno);
            return BadRequest(retorno);
        }

        [HttpPost("login")]
        public ActionResult<UsuarioLoginResponse> Login([FromBody] UsuarioLoginRequest usuarioLogin)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var retorno = usuarioAppServico.Login(usuarioLogin);
            if (retorno.Sucesso)
                return Ok(retorno);
            return BadRequest(retorno);
        }

        [HttpGet("ativar")]
        public ActionResult<UsuarioAtivarResponse> ConfirmarEmail([FromQuery] UsuarioAtivarRequest usuarioAtivar)
        {
            var retorno = usuarioAppServico.Ativar(usuarioAtivar);
            return Ok(retorno);
        }

        [HttpPost("recuperar")]
        public ActionResult<UsuarioAlterarSenhaResponse> RecuperarSenha([FromBody] UsuarioAlterarSenhaRequest usuarioAlterarSenhaRequest)
        {
            var retorno = usuarioAppServico.RecuperarSenha(usuarioAlterarSenhaRequest);
            return Ok(retorno);
        }

        [HttpPost("redefinir")]
        public ActionResult<UsuarioRedefinirResponse> RedefinirSenha([FromBody] UsuarioRedefinirRequest usuarioRedefinirRequest)
        {
            var retorno = usuarioAppServico.RedefinirSenha(usuarioRedefinirRequest);
            return Ok(retorno);
        }

        [Authorize]
        [HttpPost("logout")]
        public ActionResult Logout()
        {
            var retorno = usuarioAppServico.Logout();
            return Ok(retorno);
        }

        [Authorize]
        [HttpGet("{logado}")]
        public ActionResult<UsuarioResponse> Recuperar()
        {
            string id = HttpContext.User.FindFirst("idUsuario").Value;
            var retorno = usuarioAppServico.Recuperar(id);
            return Ok(retorno);
        }
    }
}
