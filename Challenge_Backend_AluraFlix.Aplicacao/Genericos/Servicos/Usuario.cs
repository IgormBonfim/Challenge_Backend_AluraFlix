using Challenge_Backend_AluraFlix.Aplicacao.Genericos.Servicos.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Backend_AluraFlix.Aplicacao.Genericos.Servicos
{
    public class Usuario : IUsuario
    {
        public string UsuarioLogado(ClaimsPrincipal usuario)
        {

            string id = usuario.FindFirst("codigoUsuario").Value;

            if (id == null)
                throw new Exception("Nenhum usuario está logado");
            return id;
        }
    }
}
