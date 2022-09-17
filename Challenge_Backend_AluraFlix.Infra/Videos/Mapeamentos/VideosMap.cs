using Challenge_Backend_AluraFlix.Dominio.Videos.Entidades;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Backend_AluraFlix.Infra.Videos.Mapeamentos
{
    public class VideosMap : ClassMap<Video>
    {
        public VideosMap()
        {
            Table("VIDEOS");
            Id(x => x.IdVideo).Column("idVideo");
            Map(x => x.TituloVideo).Column("tituloVideo");
            Map(x => x.DescVideo).Column("descVideo");
            Map(x => x.UrlVideo).Column("urlVideo");
        }
    }
}
