using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Backend_AluraFlix.DataTransfer.Genericos.Requests
{
    public class PaginacaoRequest
    {
        public int? Pagina { get; set; }
        public int? Limite { get; set; }
    }
}
