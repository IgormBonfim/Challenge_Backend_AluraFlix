using Challenge_Backend_AluraFlix.Dominio.Favoritos.Servicos.Interfaces;
using Challenge_Backend_AluraFlix.Dominio.Usuarios.Entidades;
using Challenge_Backend_AluraFlix.Dominio.Usuarios.Servicos.Interfaces;
using Challenge_Backend_AluraFlix.Dominio.Videos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Backend_AluraFlix.Dominio.Favoritos.Servicos
{
    public class FavoritosServico : IFavoritosServico
    {
        private readonly IUsuariosServico usuarioServico;

        public FavoritosServico(IUsuariosServico usuarioServico)
        {
            this.usuarioServico = usuarioServico;
        }
        public Video AdicionarFavorito(Usuario usuario, Video video)
        {
            foreach(var videoFavorito in usuario.Videos)
            {
                if (video.IdVideo == videoFavorito.IdVideo)
                    throw new Exception("Esse vídeo já está em seus favoritos");
            }
            usuario.Videos.Add(video);
            usuarioServico.Editar(usuario);
            return video;
        }
    }
}
