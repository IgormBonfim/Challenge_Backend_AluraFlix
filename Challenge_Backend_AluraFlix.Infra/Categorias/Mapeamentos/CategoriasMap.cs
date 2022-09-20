using Challenge_Backend_AluraFlix.Dominio.Categorias.Entidades;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Backend_AluraFlix.Infra.Categorias.Mapeamentos
{
    public class CategoriasMap : ClassMap<Categoria>
    {
        public CategoriasMap()
        {
            Table("categorias");
            Id(x => x.IdCategoria).Column("IdCategoria");
            Map(x => x.TituloCategoria).Column("TituloCategoria");
            Map(x => x.CorCategoria).Column("CorCategoria");
        }

    }
}
