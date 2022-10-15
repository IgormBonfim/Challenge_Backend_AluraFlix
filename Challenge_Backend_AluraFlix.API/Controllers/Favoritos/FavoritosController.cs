using Challenge_Backend_AluraFlix.Aplicacao.Favoritos.Servicos.Interfaces;
using Challenge_Backend_AluraFlix.DataTransfer.Favoritos.Requests;
using Challenge_Backend_AluraFlix.DataTransfer.Videos.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Challenge_Backend_AluraFlix.API.Controllers.Favoritos
{
    [Route("api/favoritos")]
    [ApiController]
    public class FavoritosController : ControllerBase
    {
        private readonly IFavoritosAppServico favoritosAppServico;

        public FavoritosController(IFavoritosAppServico favoritosAppServico)
        {
            this.favoritosAppServico = favoritosAppServico;
        }

        [HttpPost]
        public ActionResult<VideoResponse> AdicionarFavorito([FromBody] FavoritoInserirRequest favoritoInserirRequest)
        {
            string id = HttpContext.User.FindFirst("idUsuario").Value;
            favoritoInserirRequest.IdUsuario = id;

            var retorno = favoritosAppServico.AdicionarFavorito(favoritoInserirRequest);
            return Ok(retorno);
        }
    }
}
