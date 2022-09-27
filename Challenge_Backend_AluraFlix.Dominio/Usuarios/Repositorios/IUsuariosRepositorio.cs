using Challenge_Backend_AluraFlix.Dominio.Usuarios.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Backend_AluraFlix.Dominio.Usuarios.Repositorios
{
    public interface IUsuariosRepositorio
    {
        void Inserir(UsuarioPassword usuario);
        IQueryable<UsuarioPassword> Buscar();
    }
}
