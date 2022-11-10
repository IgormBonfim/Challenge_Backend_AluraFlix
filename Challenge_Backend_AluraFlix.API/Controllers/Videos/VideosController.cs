using Challenge_Backend_AluraFlix.Aplicacao.Genericos.Servicos.Interfaces;
using Challenge_Backend_AluraFlix.Aplicacao.Videos.Servicos.Interfaces;
using Challenge_Backend_AluraFlix.DataTransfer.Genericos.Requests;
using Challenge_Backend_AluraFlix.DataTransfer.Genericos.Responses;
using Challenge_Backend_AluraFlix.DataTransfer.Videos.Requests;
using Challenge_Backend_AluraFlix.DataTransfer.Videos.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Challenge_Backend_AluraFlix.API.Controllers.Videos
{
    [Authorize]
    [Route("api/videos")]
    [ApiController]
    public class VideosController : ControllerBase
    {
        private readonly IVideosAppServico videosAppServico;
        private readonly IUsuario usuario;

        public VideosController(IVideosAppServico videosAppServico, IUsuario usuario)
        {
            this.videosAppServico = videosAppServico;
            this.usuario = usuario;
        }

        [HttpPost]
        public ActionResult<VideoIdResponse> Inserir([FromBody] VideoInserirRequest inserirRequest)
        {
            var retorno = videosAppServico.Inserir(inserirRequest);
            return Created($"/api/videos/{retorno.IdVideo}",retorno);
        }

        [HttpGet("search")]
        public ActionResult<ListaPaginadaResponse<VideoResponse>> BuscarPorTitulo([FromQuery] VideoBuscarRequest request)
        {
            var retorno = videosAppServico.Buscar(request);
            return Ok(retorno);
        }

        [AllowAnonymous]
        [HttpGet("free")]
        public ActionResult<IList<VideoResponse>> VideosGratuitos()
        {
            VideoBuscarRequest filtros = new VideoBuscarRequest();
            var retorno = videosAppServico.Buscar(filtros);
            return Ok(retorno);
        }

        [HttpGet("{id}")]
        public ActionResult<VideoResponse> RecuperarPorId(int id)
        {
            var retorno = videosAppServico.Recuperar(id);
            return Ok(retorno);
        }

        [HttpGet("favoritos")]
        public ActionResult<IList<VideoResponse>> RecuperarFavoritos()
        {
            string id = usuario.UsuarioLogado(User);
            var result = videosAppServico.Favoritos(id);
            return Ok(result);
        }


        [HttpPut("{id}")]
        public ActionResult Editar(int id, [FromBody] VideoEditarRequest editarRequest)
        {
            editarRequest.IdVideo = id;
            var retorno = videosAppServico.Editar(editarRequest);
            return Ok(retorno);
        }

        [HttpDelete("{id}")]
        public ActionResult<MensagemResponse> Deletar(int id)
        {
            var retorno = videosAppServico.Deletar(id);
            return Ok(retorno);
        }
    }
}
