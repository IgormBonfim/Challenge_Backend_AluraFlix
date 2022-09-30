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
        private readonly IIdentityServico identityServico;

        public UsuariosController(IIdentityServico identityServico)
        {
            this.identityServico = identityServico;
        }

        [HttpPost("cadastrar")]
        public async Task<ActionResult<UsuarioCadastroResponse>> Cadastrar(UsuarioCadastroRequest usuarioCadastro)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var retorno = await identityServico.CadastrarUsuario(usuarioCadastro);
            if (retorno.Sucesso)
                return Ok(retorno);
            return BadRequest(retorno);
        }

        [HttpPost("login")]
        public async Task<ActionResult<UsuarioLoginResponse>> Login(UsuarioLoginRequest usuarioLogin)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var retorno = await identityServico.Login(usuarioLogin);
            if (retorno.Sucesso)
                return Ok(retorno);
            return BadRequest(retorno);
        }
    }
}
