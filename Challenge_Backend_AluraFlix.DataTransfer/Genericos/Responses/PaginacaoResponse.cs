using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Backend_AluraFlix.DataTransfer.Genericos.Responses
{
    public class PaginacaoResponse
    {
        public int Limit { get; set; }
        public int Offset { get; set; }
    }
}
