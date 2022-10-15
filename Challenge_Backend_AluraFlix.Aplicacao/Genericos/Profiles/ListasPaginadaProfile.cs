using AutoMapper;
using Challenge_Backend_AluraFlix.DataTransfer.Genericos.Responses;
using Challenge_Backend_AluraFlix.Dominio.Genericos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Backend_AluraFlix.Aplicacao.Genericos.Profiles
{
    public class ListasPaginadaProfile : Profile
    {
        public ListasPaginadaProfile()
        {
            CreateMap(typeof(ListaPaginada<>), typeof(ListaPaginadaResponse<>));
        }
    }
}
