using Challenge_Backend_AluraFlix.Dominio.Categorias.Entidades;
using Challenge_Backend_AluraFlix.Dominio.Categorias.Repositorios;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Backend_AluraFlix.Infra.Categorias
{
    public class CategoriasRepositorio : ICategoriasRepositorio
    {
        private readonly ISession session;

        public CategoriasRepositorio(ISession session)
        {
            this.session = session;
        }
        
        public void Deletar(Categoria deletar)
        {
            session.Delete(deletar);
        }

        public Categoria Editar(Categoria editar)
        {
            session.Update(editar);
            return editar;
        }

        public Categoria Inserir(Categoria inserir)
        {
            int id = (int)session.Save(inserir);
            inserir.SetIdCategoria(id);
            return inserir;
        }

        public IQueryable<Categoria> Query()
        {
            return session.Query<Categoria>();
        }

        public Categoria Recuperar(int id)
        {
            return session.Get<Categoria>(id);
        }
    }
}
