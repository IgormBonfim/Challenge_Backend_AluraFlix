using AutoMapper;
using Challenge_Backend_AluraFlix.DataTransfer.Categorias.Requests;
using Challenge_Backend_AluraFlix.DataTransfer.Categorias.Responses;
using Challenge_Backend_AluraFlix.Dominio.Categorias.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Backed_AluraFlix.Aplicacao.Categorias.Profiles
{
    public class CategoriasProfile : Profile
    {
        public CategoriasProfile()
        {
            CreateMap<CategoriaInserirRequest, Categoria>();
            CreateMap<CategoriaEditarRequest, Categoria>();
            CreateMap<Categoria, CategoriaIdResponse>();
            CreateMap<Categoria, CategoriaResponse>();
        }
    }
}
