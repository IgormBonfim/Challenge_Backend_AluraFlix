using AutoMapper;
using Challenge_Backend_AluraFlix.Aplicacao.Favoritos.Servicos.Interfaces;
using Challenge_Backend_AluraFlix.DataTransfer.Favoritos.Requests;
using Challenge_Backend_AluraFlix.DataTransfer.Videos.Responses;
using Challenge_Backend_AluraFlix.Dominio.Favoritos.Servicos.Interfaces;
using Challenge_Backend_AluraFlix.Dominio.Usuarios.Entidades;
using Challenge_Backend_AluraFlix.Dominio.Usuarios.Servicos.Interfaces;
using Challenge_Backend_AluraFlix.Dominio.Videos.Entidades;
using Challenge_Backend_AluraFlix.Dominio.Videos.Servicos.Interfaces;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Backend_AluraFlix.Aplicacao.Favoritos.Servicos
{
    public class FavoritosAppServico : IFavoritosAppServico
    {
        private readonly ISession session;
        private readonly IUsuariosServico usuariosServico;
        private readonly IVideosServico videosServico;
        private readonly IFavoritosServico favoritosServico;
        private readonly IMapper mapper;

        public FavoritosAppServico(ISession session, IUsuariosServico usuariosServico, IVideosServico videosServico, IFavoritosServico favoritosServico, IMapper mapper)
        {
            this.session = session;
            this.usuariosServico = usuariosServico;
            this.videosServico = videosServico;
            this.favoritosServico = favoritosServico;
            this.mapper = mapper;
        }
        public VideoResponse AdicionarFavorito(FavoritoInserirRequest favoritoInserirRequest)
        {
            ITransaction transacao = session.BeginTransaction();

            try
            {
                Usuario usuario = usuariosServico.Validar(favoritoInserirRequest.IdUsuario);
                Video video = videosServico.Validar(favoritoInserirRequest.IdVideo);

                Video videoFavoritado = favoritosServico.AdicionarFavorito(usuario, video);

                if (transacao.IsActive)
                    transacao.Commit();
                return mapper.Map<VideoResponse>(videoFavoritado);
            }
            catch
            {
                if (transacao.IsActive)
                    transacao.Rollback();
                throw;
            }
        }
    }
}
