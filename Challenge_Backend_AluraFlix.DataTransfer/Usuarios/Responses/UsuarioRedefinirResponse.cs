using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Backend_AluraFlix.DataTransfer.Usuarios.Responses
{
    public class UsuarioRedefinirResponse
    {
        public bool Sucesso { get; private set; }
        public List<string> Erros { get; private set; }

        public UsuarioRedefinirResponse()
        {
            Erros = new List<string>();
        }

        public UsuarioRedefinirResponse(bool sucesso = true) : this()
        {
            Sucesso = sucesso;
        }

        public void AdicionarErro(string erro)
        {
            Erros.Add(erro);
        }

        public void AdicionarErros(IEnumerable<string> erros)
        {
            Erros.AddRange(erros);
        }
    }
}
