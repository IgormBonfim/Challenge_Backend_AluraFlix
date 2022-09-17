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

        public VideosAppServico(IVideosServico videosServico, ISession session)
        {
            this.videosServico = videosServico;
            this.session = session;
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
                var videoResponse = new VideoIdResponse() { VideoId = videoInserir.IdVideo };
                return videoResponse;
            }
            catch
            {
                if (transacao.IsActive)
                    transacao.Rollback();
                return null;
            }

            

        }
    }
}
