using Challenge_Backend_AluraFlix.Aplicacao.Videos.Servicos.Interfaces;
using Challenge_Backend_AluraFlix.DataTransfer.Genericos.Requests;
using Challenge_Backend_AluraFlix.DataTransfer.Genericos.Responses;
using Challenge_Backend_AluraFlix.DataTransfer.Videos.Requests;
using Challenge_Backend_AluraFlix.DataTransfer.Videos.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Challenge_Backend_AluraFlix.API.Controllers.Videos
{
    [Route("api/videos")]
    [ApiController]
    public class VideosController : ControllerBase
    {
        private readonly IVideosAppServico videosAppServico;

        public VideosController(IVideosAppServico videosAppServico)
        {
            this.videosAppServico = videosAppServico;
        }

        [HttpPost]
        public ActionResult<VideoIdResponse> Inserir([FromBody] VideoInserirRequest inserirRequest)
        {
            var retorno = videosAppServico.Inserir(inserirRequest);
            return Ok(retorno);
        }

        [HttpGet("search")]
        public ActionResult<VideoResponse> BuscarPorTitulo([FromQuery] VideoBuscarRequest request)
        {
            var retorno = videosAppServico.Buscar(request);
            return Ok(retorno);
        }

        [HttpGet("{id}")]
        public ActionResult<VideoResponse> RecuperarPorId(int id)
        {
            var retorno = videosAppServico.Recuperar(id);
            return Ok(retorno);
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
