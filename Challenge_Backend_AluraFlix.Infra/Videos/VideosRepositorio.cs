using Challenge_Backend_AluraFlix.Dominio.Videos.Entidades;
using Challenge_Backend_AluraFlix.Dominio.Videos.Repositorios;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Backend_AluraFlix.Infra.Videos
{
    public class VideosRepositorio : IVideosRepositorio
    {
        private readonly ISession session;

        public VideosRepositorio(ISession session)
        {
            this.session = session;
        }
        public void Deletar(Video video)
        {
            session.Delete(video);
        }

        public Video Editar(Video video)
        {
            session.Update(video);
            return video;
        }

        public Video Inserir(Video video)
        {
            int id = (int)session.Save(video);
            video.SetIdVideo(id);
            return video;
        }

        public IQueryable<Video> Query()
        {
            return session.Query<Video>();
        }

        public Video Recuperar(int id)
        {
            return session.Get<Video>(id);
        }
    }
}
