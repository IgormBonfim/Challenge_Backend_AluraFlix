using Challenge_Backend_AluraFlix.Aplicacao.Usuarios.Servicos.Interfaces;
using Challenge_Backend_AluraFlix.Autenticacao.Servicos.Interfaces;
using Challenge_Backend_AluraFlix.DataTransfer.Usuarios.Requests;
using Challenge_Backend_AluraFlix.DataTransfer.Usuarios.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Backend_AluraFlix.Aplicacao.Usuarios.Servicos
{
    public class UsuarioAppServico : IUsuarioAppServico
    {
        private readonly IIdentityServico identityServico;
        private readonly IEmailServico emailServico;

        public UsuarioAppServico(IIdentityServico identityServico, IEmailServico emailServico)
        {
            this.identityServico = identityServico;
            this.emailServico = emailServico;
        }
        public UsuarioAtivarResponse Ativar(UsuarioAtivarRequest ativarRequest)
        {
            return identityServico.Ativar(ativarRequest).Result;
        }

        public UsuarioCadastroResponse Cadastrar(UsuarioCadastroRequest cadastroRequest)
        {
            UsuarioCadastroResponse usuarioCadastroResponse = identityServico.CadastrarUsuario(cadastroRequest).Result;
            if (usuarioCadastroResponse.Sucesso)
            {
                var mensagem = emailServico.CriarMensagem(new[] { cadastroRequest.Email }, "Ative sua conta - AluraFlix", usuarioCadastroResponse.IdUsuario, usuarioCadastroResponse.TokenEmail);
                var corpoEmail = emailServico.CriaCorpoEmail(mensagem);
                emailServico.EnviarEmail(corpoEmail);
            }

            return usuarioCadastroResponse;
        }

        public UsuarioLoginResponse Login(UsuarioLoginRequest loginRequest)
        {
            return identityServico.Login(loginRequest).Result;
        }

        public UsuarioLogoutResponse Logout()
        {
            return identityServico.Logout();
        }
    }
}
