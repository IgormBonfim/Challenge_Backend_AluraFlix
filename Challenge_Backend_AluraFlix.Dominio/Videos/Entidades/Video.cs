using Challenge_Backend_AluraFlix.Dominio.Categorias.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Backend_AluraFlix.Dominio.Videos.Entidades
{
    public class Video
    {
        public virtual int IdVideo { get; protected set; }
        public virtual string TituloVideo { get; protected set; }
        public virtual string? DescVideo { get; protected set; }
        public virtual string UrlVideo { get; protected set; }
        public virtual Categoria CategoriaVideo { get; protected set; }

        public Video()
        {

        }

        public Video(string? titulo, string? desc, string? url, Categoria? categoria)
        {
            SetTituloVideo(titulo);
            SetDescVideo(desc);
            SetUrlVideo(url);
            SetCategoriaVideo(categoria);
        }

        public virtual void SetIdVideo(int id)
        {
            if(id < 0)
                throw new Exception("O campo Id não pode ser inferior a 0!");
            IdVideo = id;
        }

        public virtual void SetTituloVideo(string? titulo)
        {
            if (string.IsNullOrWhiteSpace(titulo))
                throw new Exception("Titulo não pode ser vazio!");
            if (titulo.Length > 100)
                throw new Exception("O Titulo não deve conter o número de caracteres superior a 100!");
            TituloVideo = titulo;
        }

        public virtual void SetDescVideo(string? desc)
        {
            if (desc != null && desc.Length < 5)
                throw new Exception("Descrição não deve ser inferior à 5 caracteres!");
            if (desc.Length > 255)
                throw new Exception("A Descrição não deve conter o número de caracteres superior a 255!");
            DescVideo = desc;
        }

        public virtual void SetUrlVideo(string? url)
        {
            if (string.IsNullOrWhiteSpace(url))
                throw new Exception("URL não pode ser vazio!");
            if (url.Length > 255)
                throw new Exception("A URL não deve conter o número de caracteres superior a 255!");
            UrlVideo = url;
        }

        public virtual void SetCategoriaVideo(Categoria? categoria)
        {
            if (categoria == null)
                throw new Exception("O campo categoria é obrigatório!");
            CategoriaVideo = categoria;
        }
    }
}
