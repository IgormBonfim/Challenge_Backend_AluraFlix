using Challenge_Backend_AluraFlix.Dominio.Videos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Backend_AluraFlix.Dominio.Usuarios.Entidades
{
    public class Usuario
    {
        public virtual string Id { get; set; }
        public virtual string Email { get; set; }
        public virtual IList<Video> Videos { get; set; }

        public Usuario()
        {

        }

    }
}
