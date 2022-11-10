using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Backend_AluraFlix.DataTransfer.Favoritos.Requests
{
    public class FavoritoRemoverRequest
    {
        public string? IdUsuario { get; set; }
        public int IdVideo { get; set; }
    }
}
