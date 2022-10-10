using AutoMapper;
using Challenge_Backend_AluraFlix.DataTransfer.Usuarios.Responses;
using Challenge_Backend_AluraFlix.Dominio.Usuarios.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Backend_AluraFlix.Aplicacao.Usuarios.Profiles
{
    public class UsuariosProfile : Profile
    {
        public UsuariosProfile()
        {
            CreateMap<Usuario, UsuarioResponse>();
        }
    }
}
