using Challenge_Backend_AluraFlix.DataTransfer.Favoritos.Requests;
using Challenge_Backend_AluraFlix.DataTransfer.Videos.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Backend_AluraFlix.Aplicacao.Favoritos.Servicos.Interfaces
{
    public interface IFavoritosAppServico
    {
        VideoResponse AdicionarFavorito(FavoritoInserirRequest favoritoInserirRequest);
        VideoResponse RemoverFavorito(FavoritoRemoverRequest favoritoRemoverRequest);
    }
}
