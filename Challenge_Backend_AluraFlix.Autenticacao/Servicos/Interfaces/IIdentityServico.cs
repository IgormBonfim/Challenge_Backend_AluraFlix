using Challenge_Backend_AluraFlix.DataTransfer.Usuarios.Requests;
using Challenge_Backend_AluraFlix.DataTransfer.Usuarios.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Backend_AluraFlix.Autenticacao.Servicos.Interfaces
{
    public interface IIdentityServico
    {
        Task<UsuarioAtivarResponse> Ativar(UsuarioAtivarRequest usuarioAtivarRequest);
        Task<UsuarioCadastroResponse> CadastrarUsuario(UsuarioCadastroRequest usuarioCadastro);
        Task<UsuarioLoginResponse> Login(UsuarioLoginRequest usuarioLoginRequest);
        UsuarioLogoutResponse Logout();
        Task<UsuarioAlterarSenhaResponse> RecuperarSenha(UsuarioAlterarSenhaRequest usuarioAlterarSenhaRequest);
        Task<UsuarioRedefinirResponse> RedefinirSenha(UsuarioRedefinirRequest usuarioRedefinirRequest);
    }
}
