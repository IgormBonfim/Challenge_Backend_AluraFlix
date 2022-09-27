using Challenge_Backend_AluraFlix.Aplicacao.Usuarios.Servicos.Interfaces;
using Challenge_Backend_AluraFlix.DataTransfer.Usuarios.Requests;
using Challenge_Backend_AluraFlix.DataTransfer.Usuarios.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Challenge_Backend_AluraFlix.API.Controllers.Usuarios
{
    [Route("api/usuarios")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IAutenticacaoAppServico autenticacaoAppServico;

        public UsuariosController(IAutenticacaoAppServico autenticacaoAppServico)
        {
            this.autenticacaoAppServico = autenticacaoAppServico;
        }

        [HttpPost]
        public IActionResult Registrar(UsuarioRegistrarRequest request)
        {
            var retorno = autenticacaoAppServico.Registrar(request);
            return Ok(retorno);
        }
    }
}
