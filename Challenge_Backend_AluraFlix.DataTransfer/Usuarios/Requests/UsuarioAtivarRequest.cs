using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Backend_AluraFlix.DataTransfer.Usuarios.Requests
{
    public class UsuarioAtivarRequest
    {
        public string IdUsuario { get; set; }
        public string TokenAtivacao { get; set; }
    }
}
