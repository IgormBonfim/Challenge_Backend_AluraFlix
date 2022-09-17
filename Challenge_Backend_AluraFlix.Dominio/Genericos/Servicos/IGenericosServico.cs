using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Backend_AluraFlix.Dominio.Genericos.Servicos
{
    public interface IGenericosServico<T> where T : class
    {
        T Validar(int id);
        T Inserir(T inserir);
        T Editar(T editar);
        void Deletar(int id);
        IList<T> Listar();
    }
}
