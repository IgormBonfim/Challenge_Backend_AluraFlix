using Challenge_Backend_AluraFlix.Dominio.Usuarios.Entidades;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Backend_AluraFlix.Infra.Usuarios.Mapeamentos
{
    public class UsuarioMap : ClassMap<Usuario>
    {
        public UsuarioMap()
        {
            Table("aspnetusers");
            Id(x => x.Id).Column("Id");
            Map(x => x.Email).Column("Email");
            HasManyToMany(x => x.Videos)
            .Table("favoritos")
            .ParentKeyColumn("IdUsuario")
            .ChildKeyColumn("IdVideo")
            .LazyLoad()
            .Cascade.SaveUpdate();
        }
    }
}
