using AutoMapper;
using Challenge_Backend_AluraFlix.Aplicacao.Usuarios.Servicos.Interfaces;
using Challenge_Backend_AluraFlix.Autenticacao.Servicos.Interfaces;
using Challenge_Backend_AluraFlix.DataTransfer.Usuarios.Requests;
using Challenge_Backend_AluraFlix.DataTransfer.Usuarios.Responses;
using Challenge_Backend_AluraFlix.Dominio.Usuarios.Entidades;
using Challenge_Backend_AluraFlix.Dominio.Usuarios.Servicos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Backend_AluraFlix.Aplicacao.Usuarios.Servicos
{
    public class UsuariosAppServico : IUsuariosAppServico
    {
        private readonly IIdentityServico identityServico;
        private readonly IUsuariosServico usuariosServico;
        private readonly IEmailServico emailServico;
        private readonly IMapper mapper;

        public UsuariosAppServico(IIdentityServico identityServico, IUsuariosServico usuariosServico, IEmailServico emailServico, IMapper mapper)
        {
            this.identityServico = identityServico;
            this.usuariosServico = usuariosServico;
            this.emailServico = emailServico;
            this.mapper = mapper;
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

        public UsuarioResponse Recuperar(string id)
        {
            Usuario usuario = usuariosServico.Validar(id);
            return mapper.Map<UsuarioResponse>(usuario);
        }

        public UsuarioAlterarSenhaResponse RecuperarSenha(UsuarioAlterarSenhaRequest usuarioAlterarSenhaRequest)
        {
            UsuarioAlterarSenhaResponse result = identityServico.RecuperarSenha(usuarioAlterarSenhaRequest).Result;
            return result;
        }

        public UsuarioRedefinirResponse RedefinirSenha(UsuarioRedefinirRequest usuarioRedefinirRequest)
        {
            UsuarioRedefinirResponse result = identityServico.RedefinirSenha(usuarioRedefinirRequest).Result;
            return result;
        }


    }
}
