using Challenge_Backend_AluraFlix.DataTransfer.Usuarios.Requests;
using Challenge_Backend_AluraFlix.DataTransfer.Usuarios.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Backend_AluraFlix.Aplicacao.Usuarios.Servicos.Interfaces
{
    public interface IUsuariosAppServico
    {
        UsuarioAtivarResponse Ativar(UsuarioAtivarRequest ativarRequest);
        UsuarioCadastroResponse Cadastrar(UsuarioCadastroRequest cadastroRequest);
        UsuarioLoginResponse Login(UsuarioLoginRequest loginRequest);
        UsuarioLogoutResponse Logout();
        UsuarioAlterarSenhaResponse RecuperarSenha(UsuarioAlterarSenhaRequest usuarioAlterarSenhaRequest);
        UsuarioRedefinirResponse RedefinirSenha(UsuarioRedefinirRequest usuarioRedefinirRequest);
        UsuarioResponse Recuperar(string id);
    }
}
