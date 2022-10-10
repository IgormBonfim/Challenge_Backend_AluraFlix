using Challenge_Backend_AluraFlix.Dominio.Usuarios.Entidades;
using Challenge_Backend_AluraFlix.Dominio.Usuarios.Repositorios;
using Challenge_Backend_AluraFlix.Infra.Genericos;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Backend_AluraFlix.Infra.Usuarios
{
    public class UsuariosRepositorio : GenericosRepositorio<Usuario>, IUsuariosRepositorio
    {
        public UsuariosRepositorio(ISession session) : base(session) { }
    }
}
