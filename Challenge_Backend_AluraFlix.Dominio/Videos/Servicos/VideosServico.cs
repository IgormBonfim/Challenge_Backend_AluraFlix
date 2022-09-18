using Challenge_Backend_AluraFlix.Dominio.Videos.Entidades;
using Challenge_Backend_AluraFlix.Dominio.Videos.Repositorios;
using Challenge_Backend_AluraFlix.Dominio.Videos.Servicos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Backend_AluraFlix.Dominio.Videos.Servicos
{
    public class VideosServico : IVideosServico
    {
        private readonly IVideosRepositorio videosRepositorio;

        public VideosServico(IVideosRepositorio videosRepositorio)
        {
            this.videosRepositorio = videosRepositorio;
        }

        public IList<Video> Buscar(string busca)
        {
            return videosRepositorio.Query().Where(x => x.TituloVideo.Contains(busca)).ToList();
        }

        public void Deletar(int videoId)
        {
            videosRepositorio.Deletar(Validar(videoId));
        }

        public Video Editar(Video video)
        {
            Video videoEditar = Validar(video.IdVideo);

            if (videoEditar.TituloVideo != video.TituloVideo && video.TituloVideo != null) videoEditar.SetTituloVideo(video.TituloVideo);
            if (videoEditar.DescVideo != video.DescVideo && video.DescVideo != null) videoEditar.SetDescVideo(video.DescVideo);
            if (videoEditar.UrlVideo != video.UrlVideo && video.UrlVideo != null) videoEditar.SetUrlVideo(video.UrlVideo);

            return videosRepositorio.Editar(videoEditar);
        }

        public Video Inserir(Video video)
        {
            return videosRepositorio.Inserir(video);
        }

        public Video Instanciar(string? titulo, string? desc, string? url)
        {
            return new Video(titulo, desc, url);
        }

        public Video Validar(int id)
        {
            Video videoValidar = videosRepositorio.Recuperar(id);
            if (videoValidar == null)
                throw new Exception("Vídeo não encontrado");
            return videoValidar;
        }

        public IList<Video> Videos()
        {
            IList<Video> videosList = videosRepositorio.Query().ToList();
            return videosList;
        }
    }
}
