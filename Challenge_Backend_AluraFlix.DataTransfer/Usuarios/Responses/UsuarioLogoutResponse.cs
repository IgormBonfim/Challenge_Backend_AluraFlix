using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Backend_AluraFlix.DataTransfer.Usuarios.Responses
{
    public class UsuarioLogoutResponse
    {
        public bool Sucesso { get; private set; }

        public UsuarioLogoutResponse(bool sucesso = true)
        {
            Sucesso = sucesso;
        }
    }
}
