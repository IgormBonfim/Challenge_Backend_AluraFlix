using Challenge_Backend_AluraFlix.Dominio.Categorias.Entidades;
using Challenge_Backend_AluraFlix.Dominio.Categorias.Repositorios;
using Challenge_Backend_AluraFlix.Dominio.Categorias.Servicos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Backend_AluraFlix.Dominio.Categorias.Servicos
{
    public class CategoriasServico : ICategoriasServico
    {
        private readonly ICategoriasRepositorio categoriasRepositorio;

        public CategoriasServico(ICategoriasRepositorio categoriasRepositorio)
        {
            this.categoriasRepositorio = categoriasRepositorio;
        }

        public void Deletar(int id)
        {
            categoriasRepositorio.Deletar(Validar(id));
        }

        public Categoria Editar(Categoria editar)
        {
            throw new NotImplementedException();
        }

        public Categoria Inserir(Categoria inserir)
        {
            throw new NotImplementedException();
        }

        public Categoria Instanciar(string? titulo, string? cor)
        {
            return new Categoria(titulo, cor);
        }

        public IList<Categoria> Listar()
        {
            IList<Categoria> categoriasList = categoriasRepositorio.Query().ToList();
            return categoriasList;
        }

        public Categoria Validar(int id)
        {
            Categoria categoriaValidar = categoriasRepositorio.Recuperar(id);
            if (categoriaValidar == null)
                throw new Exception("Categoria não encontrada");
            return categoriaValidar;
        }
    }
}
