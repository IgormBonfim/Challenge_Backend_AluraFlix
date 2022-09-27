using Challenge_Backend_AluraFlix.Dominio.Usuarios.Entidades;
using Challenge_Backend_AluraFlix.Dominio.Usuarios.Repositorios;
using Challenge_Backend_AluraFlix.Dominio.Usuarios.Servicos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Backend_AluraFlix.Dominio.Usuarios.Servicos
{
    public class UsuariosServico : IUsuariosServico
    {
        private readonly IUsuariosRepositorio usuariosRepositorio;

        public UsuariosServico(IUsuariosRepositorio usuariosRepositorio)
        {
            this.usuariosRepositorio = usuariosRepositorio;
        }
        public Usuario Inserir(UsuarioPassword usuarioPassword)
        {
            usuariosRepositorio.Inserir(usuarioPassword);
            Usuario usuario = InstanciarUsuario(usuarioPassword.IdUsuario, usuarioPassword.NomeUsuario, usuarioPassword.SobrenomeUsuario, usuarioPassword.EmailUsuario);
            return usuario;
        }

        public UsuarioPassword Instanciar(string? nomeUsuario, string? sobrenomeUsuario, string? emailUsuario, string? senha)
        {
            UsuarioPassword usuario = new UsuarioPassword(nomeUsuario, sobrenomeUsuario, emailUsuario, senha);
            return usuario;
        }

        public Usuario InstanciarUsuario(Guid id, string? nomeUsuario, string? sobrenomeUsuario, string? emailUsuario)
        {
            Usuario usuario = new Usuario(id, nomeUsuario, sobrenomeUsuario, emailUsuario);
            return usuario;
        }

        public Usuario Validar(IQueryable<UsuarioPassword> query)
        {
            var usuario = query.FirstOrDefault();

            if (usuario == null)
                throw new Exception("Usuario não encontrado");

            return InstanciarUsuario(usuario.IdUsuario ,usuario.NomeUsuario, usuario.SobrenomeUsuario, usuario.EmailUsuario);
        }
    }
}
