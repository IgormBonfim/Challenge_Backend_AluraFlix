using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Backend_AluraFlix.Dominio.Categorias.Entidades
{
    public class Categoria
    {
        public virtual int IdCategoria { get; protected set; }
        public virtual string TituloCategoria { get; protected set; }
        public virtual string CorCategoria { get; protected set; }

        public Categoria()
        {
              
        }

        public Categoria(string? titulo, string? cor)
        {
            SetTituloCategoria(titulo);
            SetCorCategoria(cor);
        }
        
        public virtual void SetIdCategoria(int id)
        {
            if (id < 0)
                throw new Exception("O Campo id não pode ser inferior a 0");
            IdCategoria = id;
        }

        public virtual void SetTituloCategoria(string? titulo)
        {
            if (string.IsNullOrWhiteSpace(titulo))
                throw new Exception("O campo título é o obrigatório!");
            TituloCategoria = titulo;
        }

        public virtual void SetCorCategoria(string? cor)
        {
            if (string.IsNullOrWhiteSpace(cor))
                throw new Exception("O campo cor é obrigatório!");
            CorCategoria = cor;
        }
    }
}
