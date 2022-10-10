using Challenge_Backend_AluraFlix.Dominio.Categorias.Entidades;
using Challenge_Backend_AluraFlix.Dominio.Categorias.Repositorios;
using Challenge_Backend_AluraFlix.Dominio.Genericos.Repositorios;
using Challenge_Backend_AluraFlix.Infra.Genericos;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Backend_AluraFlix.Infra.Categorias
{
    public class CategoriasRepositorio : GenericosRepositorio<Categoria>, ICategoriasRepositorio
    {
        public CategoriasRepositorio(ISession session) : base(session) { }
    }
}
