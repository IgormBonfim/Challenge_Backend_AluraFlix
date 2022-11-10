using Challenge_Backend_AluraFlix.Dominio.Favoritos.Servicos.Interfaces;
using Challenge_Backend_AluraFlix.Dominio.Usuarios.Entidades;
using Challenge_Backend_AluraFlix.Dominio.Usuarios.Servicos.Interfaces;
using Challenge_Backend_AluraFlix.Dominio.Videos.Entidades;
using Challenge_Backend_AluraFlix.Dominio.Videos.Servicos.Interfaces;


namespace Challenge_Backend_AluraFlix.Dominio.Favoritos.Servicos
{
    public class FavoritosServico : IFavoritosServico
    {
        private readonly IUsuariosServico usuariosServico;
        private readonly IVideosServico videosServico;

        public FavoritosServico(IUsuariosServico usuariosServico, IVideosServico videosServico)
        {
            this.usuariosServico = usuariosServico;
            this.videosServico = videosServico;
        }
        public Video AdicionarFavorito(string idUsuario, int idVideo)
        {
            Video video = videosServico.Validar(idVideo);

            Usuario usuario = usuariosServico.Validar(idUsuario);

            foreach(var videoFavorito in usuario.Videos)
            {
                if (video.IdVideo == videoFavorito.IdVideo)
                    throw new Exception("Esse vídeo já está em seus favoritos");
            }
            usuario.Videos.Add(video);
            usuariosServico.Editar(usuario);
            return video;
        }

        public Video Remover(string idUsuario, int idVideo)
        {
            Video video = videosServico.Validar(idVideo);

            Usuario usuario = usuariosServico.Validar(idUsuario);

            usuario.Videos.Remove(video);
            usuariosServico.Editar(usuario);
            return video;
        }
    }
}
