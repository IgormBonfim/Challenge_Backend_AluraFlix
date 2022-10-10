using Challenge_Backend_AluraFlix.DataTransfer.Videos.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Backend_AluraFlix.DataTransfer.Usuarios.Responses
{
    public class UsuarioResponse
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public IList<VideoResponse> Videos { get; set; }
    }
}
