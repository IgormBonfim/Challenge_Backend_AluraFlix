using AutoMapper;
using Challenge_Backed_AluraFlix.Aplicacao.Videos.Servicos.Interfaces;
using Challenge_Backend_AluraFlix.DataTransfer.Videos.Requests;
using Challenge_Backend_AluraFlix.DataTransfer.Videos.Responses;
using Challenge_Backend_AluraFlix.Dominio.Videos.Entidades;
using Challenge_Backend_AluraFlix.Dominio.Videos.Servicos.Interfaces;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Backed_AluraFlix.Aplicacao.Videos.Servicos
{
    public class VideosAppServico : IVideosAppServico
    {
        private readonly IVideosServico videosServico;
        private readonly ISession session;
        private readonly IMapper mapper;

        public VideosAppServico(IVideosServico videosServico, ISession session, IMapper mapper)
        {
            this.videosServico = videosServico;
            this.session = session;
            this.mapper = mapper;
        }

        public VideoIdResponse Inserir(VideoInserirRequest inserirRequest)
        {
            Video videoInserir = videosServico.Instanciar(inserirRequest.TituloVideo, inserirRequest.DescVideo, inserirRequest.UrlVideo);

            ITransaction transacao = session.BeginTransaction();

            try
            {
                videoInserir = videosServico.Inserir(videoInserir);
                if (transacao.IsActive)
                    transacao.Commit();
                return mapper.Map<VideoIdResponse>(videoInserir);

            }
            catch
            {
                if (transacao.IsActive)
                    transacao.Rollback();
                return null;
            }
        }

        public IList<VideoResponse> ListarTodos()
        {
            IList<Video> videosDb = videosServico.Videos();
            IList<VideoResponse> videosRetorno = new List<VideoResponse>();

            foreach (var video in videosDb)
            {
                var videoResponse = new VideoResponse
                {
                    IdVideo = video.IdVideo,
                    TituloVideo = video.TituloVideo,
                    DescVideo = video.DescVideo,
                    UrlVideo = video.UrlVideo
                };
                videosRetorno.Add(videoResponse);
            }
            return videosRetorno;
        }

        public VideoResponse Recuperar(int idVideo)
        {
            Video video = videosServico.Validar(idVideo);
            return mapper.Map<VideoResponse>(video);
        }
    }
}
