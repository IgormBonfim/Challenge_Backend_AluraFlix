using Challenge_Backend_AluraFlix.DataTransfer.Genericos.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Backend_AluraFlix.DataTransfer.Favoritos.Requests
{
    public class FavoritoListarRequest : PaginacaoRequest
    {
        public string? IdUsuario { get; set; }
    }
}
