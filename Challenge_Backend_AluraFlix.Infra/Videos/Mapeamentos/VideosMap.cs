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
            Table("VIDEO");
            Id(x => x.IdVideo).Column("idVideo");
            Map(x => x.TituloVideo).Column("tituloVideo");
            Map(x => x.DescVideo).Column("descVideo");
            Map(x => x.UrlVideo).Column("urlVideo");
            Map(x => x.ImgVideo).Column("imgVideo");
            References(x => x.CategoriaVideo).Column("idCategoria");
            HasManyToMany(x => x.Usuarios)
            .Table("favoritos")
            .ParentKeyColumn("IdVideo")
            .ChildKeyColumn("IdUsuario")
            .LazyLoad()
            .Cascade.SaveUpdate();
        }
    }
}
