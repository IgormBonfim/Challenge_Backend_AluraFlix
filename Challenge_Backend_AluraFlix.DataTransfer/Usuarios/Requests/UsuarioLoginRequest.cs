using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Backend_AluraFlix.DataTransfer.Usuarios.Requests
{
    public class UsuarioLoginRequest
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
