using Challenge_Backend_AluraFlix.Dominio.Usuarios.Entidades;
using Challenge_Backend_AluraFlix.Dominio.Videos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Backend_AluraFlix.Dominio.Favoritos.Servicos.Interfaces
{
    public interface IFavoritosServico
    {
        Video AdicionarFavorito(Usuario usuario, Video video);
    }
}
