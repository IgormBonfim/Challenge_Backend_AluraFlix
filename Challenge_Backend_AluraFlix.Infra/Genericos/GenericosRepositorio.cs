using Challenge_Backend_AluraFlix.Dominio.Genericos.Entidades;
using Challenge_Backend_AluraFlix.Dominio.Genericos.Repositorios;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Backend_AluraFlix.Infra.Genericos
{
    public class GenericosRepositorio<T> : IGenericosRepositorio<T> where T : class
    {
        private readonly ISession session;

        public GenericosRepositorio(ISession session)
        {
            this.session = session;
        }

        public void Deletar(T deletar)
        {
            session.Delete(deletar);
        }

        public T Editar(T editar)
        {
            session.Update(editar);
            return editar;
        }

        public int Inserir(T inserir)
        {
            int id = (int)session.Save(inserir);
            return id;
        }

        public ListaPaginada<T> Listar(IQueryable<T> query, int qt, int pagina)
        {
            int offset = (pagina * qt) - qt;
            IList<T> lista = query.Take(qt).Skip(offset).ToList();

            double totalVideos = query.Count();
            int totalPaginas = (int)Math.Ceiling(totalVideos / qt);

            return new ListaPaginada<T>()
            {
                Pagina = pagina,
                Quantidade = qt,
                TotalPaginas = totalPaginas,
                Lista = lista
            };
        }

        public IQueryable<T> Query()
        {
            return session.Query<T>();
        }

        public T Recuperar(int id)
        {
            return session.Get<T>(id);
        }
        public T Recuperar(string id)
        {
            return session.Get<T>(id);
        }
    }
}
