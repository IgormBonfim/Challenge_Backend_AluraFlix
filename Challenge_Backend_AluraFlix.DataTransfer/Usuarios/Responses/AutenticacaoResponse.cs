using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Backend_AluraFlix.DataTransfer.Usuarios.Responses
{
    public class AutenticacaoResponse
    {
        public Guid IdUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public string SobrenomeUsuario { get; set; }
        public string EmailUsuario { get; set; }
        public string Token { get; set; }
    }
}
