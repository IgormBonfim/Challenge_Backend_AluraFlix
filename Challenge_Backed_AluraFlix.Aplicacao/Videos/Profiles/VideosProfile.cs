using AutoMapper;
using Challenge_Backend_AluraFlix.DataTransfer.Videos.Responses;
using Challenge_Backend_AluraFlix.Dominio.Videos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Backed_AluraFlix.Aplicacao.Videos.Profiles
{
    public class VideosProfile : Profile
    {
        public VideosProfile()
        {
            CreateMap<Video, VideoResponse>();
            CreateMap<Video, VideoIdResponse>();
        }
    }
}
