using Challenge_Backend_AluraFlix.Dominio.Usuarios.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Backend_AluraFlix.Dominio.Usuarios.Servicos.Interfaces
{
    public interface IUsuariosServico
    {
        Usuario Validar(string id);
        Usuario Editar(Usuario usuario);
    }
}
