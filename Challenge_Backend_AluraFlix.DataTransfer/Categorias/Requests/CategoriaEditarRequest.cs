using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Backend_AluraFlix.DataTransfer.Categorias.Requests
{
    public class CategoriaEditarRequest
    {
        public int? IdCategoria { get; set; }
        public string? TituloCategoria { get; set; }
        public string? CorCategoria { get; set; }
    }
}
