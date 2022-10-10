using Challenge_Backend_AluraFlix.Dominio.Videos.Entidades;
using Challenge_Backend_AluraFlix.Dominio.Videos.Repositorios;
using Challenge_Backend_AluraFlix.Infra.Genericos;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Backend_AluraFlix.Infra.Videos
{
    public class VideosRepositorio : GenericosRepositorio<Video>, IVideosRepositorio
    {
        public VideosRepositorio(ISession session) : base(session) { }
    }
}
