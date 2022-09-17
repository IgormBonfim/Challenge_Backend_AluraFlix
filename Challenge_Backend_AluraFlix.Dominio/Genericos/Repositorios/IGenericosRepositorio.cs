using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Backend_AluraFlix.Dominio.Genericos.Repositorios
{
    public interface IGenericosRepositorio<T> where T : class
    {
        T Recuperar(int id);
        T Inserir(T inserir);
        T Editar(T editar);
        void Deletar(T deletar);
        IQueryable<T> Query();
    }
}
