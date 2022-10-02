using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Backend_AluraFlix.DataTransfer.Usuarios.Responses
{
    public class UsuarioAlterarSenhaResponse
    {
        public bool Sucesso { get; set; }
        public string TokenAlteracao { get; set; }

        public UsuarioAlterarSenhaResponse(bool sucesso)
        {
            Sucesso = sucesso;
        }
    }
}
