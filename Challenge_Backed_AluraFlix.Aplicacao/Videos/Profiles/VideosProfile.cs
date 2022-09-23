using AutoMapper;
using Challenge_Backend_AluraFlix.DataTransfer.Videos.Requests;
using Challenge_Backend_AluraFlix.DataTransfer.Videos.Responses;
using Challenge_Backend_AluraFlix.Dominio.Videos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Backend_AluraFlix.Aplicacao.Videos.Profiles
{
    public class VideosProfile : Profile
    {
        public VideosProfile()
        {
            CreateMap<VideoInserirRequest, Video>();
            CreateMap<VideoEditarRequest, Video>();
            CreateMap<Video, VideoResponse>();
            CreateMap<Video, VideoIdResponse>();
        }
    }
}
