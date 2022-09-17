using Challenge_Backed_AluraFlix.Aplicacao.Videos.Servicos.Interfaces;
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
    }
}
