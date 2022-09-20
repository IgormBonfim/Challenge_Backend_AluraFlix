using Challenge_Backend_AluraFlix.Dominio.Categorias.Entidades;
using Challenge_Backend_AluraFlix.Dominio.Genericos.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Backend_AluraFlix.Dominio.Categorias.Servicos.Interfaces
{
    public interface ICategoriasServico : IGenericosServico<Categoria>
    {
        Categoria Instanciar(string? titulo, string? cor);
    }
}
