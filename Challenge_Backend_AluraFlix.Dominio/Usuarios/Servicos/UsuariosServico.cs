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

        public Usuario Validar(string id)
        {
            Usuario usuario = usuariosRepositorio.Recuperar(id);
            if (usuario == null)
                throw new Exception("Usuario não encontrado");
            return usuario;
        }
    }
}
