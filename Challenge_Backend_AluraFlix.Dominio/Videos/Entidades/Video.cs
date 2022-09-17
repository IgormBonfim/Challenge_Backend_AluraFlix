using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Backend_AluraFlix.Dominio.Videos.Entidades
{
    public class Video
    {
        public int IdVideo { get; protected set; }
        public string TituloVideo { get; protected set; }
        public string DescVideo { get; protected set; }
        public string UrlVideo { get; protected set; }

        public Video()
        {

        }

        public Video(string titulo, string desc, string url)
        {
            SetTituloVideo(titulo);
            SetDescVideo(desc);
            SetUrlVideo(url);
        }

        public void SetIdVideo(int id)
        {
            if(id < 0)
                throw new Exception("O campo Id não pode ser inferior a 0!");
            IdVideo = id;
        }

        public void SetTituloVideo(string titulo)
        {
            if (string.IsNullOrWhiteSpace(titulo))
            {
                throw new Exception("Titulo não pode ser vazio!");
            }
            TituloVideo = titulo;
        }

        public void SetDescVideo(string desc)
        {
            if (string.IsNullOrWhiteSpace(desc))
            {
                throw new Exception("Descrição não pode ser vazia!");
            }
            DescVideo = desc;
        }

        public void SetUrlVideo(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new Exception("URL não pode ser vazio!");
            }
            UrlVideo = url;
        }
    }
}
