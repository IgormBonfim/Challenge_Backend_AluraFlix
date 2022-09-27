using Challenge_Backend_AluraFlix.Dominio.Usuarios.Entidades;
using Challenge_Backend_AluraFlix.Dominio.Usuarios.Repositorios;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Backend_AluraFlix.Infra.Usuarios
{
    public class UsuariosRepositorio : IUsuariosRepositorio
    {
        private readonly ISession session;

        public UsuariosRepositorio(ISession session)
        {
            this.session = session;
        }

        public IQueryable<UsuarioPassword> Buscar()
        {
            return session.Query<UsuarioPassword>();
        }

        public void Inserir(UsuarioPassword usuario)
        {
            session.Save(usuario);
        }
    }
}
