using Challenge_Backend_AluraFlix.Aplicacao.Favoritos.Servicos.Interfaces;
using Challenge_Backend_AluraFlix.Aplicacao.Genericos.Servicos.Interfaces;
using Challenge_Backend_AluraFlix.DataTransfer.Favoritos.Requests;
using Challenge_Backend_AluraFlix.DataTransfer.Videos.Responses;
using Challenge_Backend_AluraFlix.Dominio.Genericos.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Challenge_Backend_AluraFlix.API.Controllers.Favoritos
{
    [Authorize]
    [Route("api/favoritos")]
    [ApiController]
    public class FavoritosController : ControllerBase
    {
        private readonly IFavoritosAppServico favoritosAppServico;
        private readonly IUsuario usuario;

        public FavoritosController(IFavoritosAppServico favoritosAppServico, IUsuario usuario)
        {
            this.favoritosAppServico = favoritosAppServico;
            this.usuario = usuario;
        }

        [HttpPost]
        public ActionResult<VideoResponse> AdicionarFavorito([FromBody] FavoritoInserirRequest favoritoInserirRequest)
        {
            favoritoInserirRequest.IdUsuario = usuario.UsuarioLogado(HttpContext);

            var retorno = favoritosAppServico.AdicionarFavorito(favoritoInserirRequest);
            return Ok(retorno);
        }

        //[HttpGet]
        //public ActionResult<ListaPaginada<VideoResponse>> Listar(FavoritoListarRequest favoritosRequest)
        //{
        //    favoritosRequest.IdUsuario = usuario.UsuarioLogado(HttpContext);

        //    var retorno = favoritosAppServico.Listar(favoritosRequest);
        //    return Ok(retorno);
        //}
    }
}
