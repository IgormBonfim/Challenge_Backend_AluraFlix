using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Backend_AluraFlix.Aplicacao.Genericos.Servicos.Interfaces
{
    public interface IUsuario
    {
        string UsuarioLogado(HttpContext context);
    }
}
