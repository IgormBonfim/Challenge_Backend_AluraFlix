using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Backend_AluraFlix.DataTransfer.Usuarios.Requests
{
    public class UsuarioLoginRequest
    {
        public string EmailUsuario { get; set; }
        public string SenhaUsuario { get; set; }
    }
}
