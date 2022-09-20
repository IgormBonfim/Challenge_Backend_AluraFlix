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

        public IList<Categoria> Buscar(IQueryable<Categoria> query)
        {
            return query.ToList();
        }

        public void Deletar(int id)
        {
            categoriasRepositorio.Deletar(Validar(id));
        }

        public Categoria Editar(Categoria editar)
        {
            Categoria categoria = Validar(editar.IdCategoria);

            if (editar.TituloCategoria != null && editar.TituloCategoria != categoria.TituloCategoria) categoria.SetTituloCategoria(editar.TituloCategoria);
            if (editar.CorCategoria != null && editar.CorCategoria != categoria.CorCategoria) categoria.SetCorCategoria(editar.CorCategoria);

            return categoriasRepositorio.Editar(categoria);
        }

        public Categoria Inserir(Categoria inserir)
        {
            return categoriasRepositorio.Inserir(inserir);
        }

        public Categoria Instanciar(string? titulo, string? cor)
        {
            return new Categoria(titulo, cor);
        }

        public IQueryable<Categoria> Query()
        {
            return categoriasRepositorio.Query();
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
