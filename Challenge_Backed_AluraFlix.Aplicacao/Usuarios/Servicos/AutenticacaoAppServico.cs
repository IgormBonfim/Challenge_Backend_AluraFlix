using Challenge_Backend_AluraFlix.Aplicacao.Usuarios.Servicos.Interfaces;
using Challenge_Backend_AluraFlix.DataTransfer.Usuarios.Requests;
using Challenge_Backend_AluraFlix.DataTransfer.Usuarios.Responses;
using Challenge_Backend_AluraFlix.Dominio.Usuario.Servicos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Backend_AluraFlix.Aplicacao.Usuarios.Servicos
{
    public class AutenticacaoAppServico : IAutenticacaoAppServico
    {
        private readonly IGeradorTokenJwt tokenJwt;

        public AutenticacaoAppServico(IGeradorTokenJwt tokenJwt)
        {
            this.tokenJwt = tokenJwt;
        }
        public AutenticacaoResponse Login(UsuarioLoginRequest usuarioLoginRequest)
        {
            throw new NotImplementedException();
        }

        public AutenticacaoResponse Registrar(UsuarioRegistrarRequest usuarioRegistrarRequest)
        {
            usuarioRegistrarRequest.IdUsuario = Guid.NewGuid();

            string tokenGerado = tokenJwt.GerarToken(usuarioRegistrarRequest.IdUsuario.Value, usuarioRegistrarRequest.NomeUsuario, usuarioRegistrarRequest.SobrenomeUsuario);

            var response = new AutenticacaoResponse
            { 
                IdUsuario = usuarioRegistrarRequest.IdUsuario.Value,
                NomeUsuario = usuarioRegistrarRequest.NomeUsuario,
                SobrenomeUsuario = usuarioRegistrarRequest.SobrenomeUsuario,
                EmailUsuario = usuarioRegistrarRequest.EmailUsuario,
                Token = tokenGerado
            };

            return response;
        }
    }
}
