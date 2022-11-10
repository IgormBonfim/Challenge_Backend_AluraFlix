using Challenge_Backend_AluraFlix.Aplicacao.Favoritos.Servicos.Interfaces;
using Challenge_Backend_AluraFlix.Aplicacao.Genericos.Servicos.Interfaces;
using Challenge_Backend_AluraFlix.DataTransfer.Favoritos.Requests;
using Challenge_Backend_AluraFlix.DataTransfer.Videos.Responses;
using Challenge_Backend_AluraFlix.Dominio.Genericos.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
            favoritoInserirRequest.IdUsuario = usuario.UsuarioLogado(User); 

            var retorno = favoritosAppServico.AdicionarFavorito(favoritoInserirRequest);
            return Ok(retorno);
        }

        [HttpPost]
        public ActionResult<VideoResponse> RemoverFavorito([FromBody] FavoritoRemoverRequest favoritoRemoverRequest)
        {
            favoritoRemoverRequest.IdUsuario = usuario.UsuarioLogado(User);

            var retorno = favoritosAppServico.RemoverFavorito(favoritoRemoverRequest);
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
