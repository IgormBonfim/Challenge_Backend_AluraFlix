using AutoMapper;
using Challenge_Backend_AluraFlix.Aplicacao.Paginacao.Servicos.Interfaces;
using Challenge_Backend_AluraFlix.Aplicacao.Videos.Servicos.Interfaces;
using Challenge_Backend_AluraFlix.DataTransfer.Genericos.Requests;
using Challenge_Backend_AluraFlix.DataTransfer.Genericos.Responses;
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

namespace Challenge_Backend_AluraFlix.Aplicacao.Videos.Servicos
{
    public class VideosAppServico : IVideosAppServico
    {
        private readonly IVideosServico videosServico;
        private readonly ISession session;
        private readonly IMapper mapper;
        private readonly IPaginacaoServico paginacaoServico;

        public VideosAppServico(IVideosServico videosServico, ISession session, IMapper mapper, IPaginacaoServico paginacaoServico)
        {
            this.videosServico = videosServico;
            this.session = session;
            this.mapper = mapper;
            this.paginacaoServico = paginacaoServico;
        }

        public IList<VideoResponse> Buscar(VideoBuscarRequest busca)
        {
            try
            {
                var paginacao = paginacaoServico.Paginar(busca);

                var videoQuery = videosServico.Query();

                if (busca.TituloVideo != null)
                {
                    videoQuery = videoQuery.Where(x => x.TituloVideo.Contains(busca.TituloVideo));
                }
                if (busca.DescVideo != null)
                {
                    videoQuery = videoQuery.Where(x => x.DescVideo.Contains(busca.DescVideo));
                }
                if (busca.UrlVideo != null)
                {
                    videoQuery = videoQuery.Where(x => x.UrlVideo.Contains(busca.UrlVideo));
                }
                if (busca.CategoriaId != null)
                {
                    videoQuery = videoQuery.Where(x => x.CategoriaVideo.IdCategoria == busca.CategoriaId);
                }

                IList<Video> videoList = videosServico.Buscar(videoQuery, paginacao.Limit, paginacao.Offset);
                return mapper.Map<IList<VideoResponse>>(videoList);
            }
            catch (Exception e)
            {
                throw e;
            }


        }

        public MensagemResponse Deletar(int idVideo)
        {
            ITransaction transacao = session.BeginTransaction();

            MensagemResponse retorno = new MensagemResponse();

            try
            {
                videosServico.Deletar(idVideo);
                if (transacao.IsActive)
                    transacao.Commit();
                retorno.Mensagem = "Video deletado com sucesso!";
                return retorno;
            }
            catch (Exception e)
            {
                retorno.Mensagem = e.Message;
                return retorno;
            }
        }

        public VideoResponse Editar(VideoEditarRequest editarRequest)
        {

            ITransaction transacao = session.BeginTransaction();

            try
            {
                editarRequest = editarRequest ?? new VideoEditarRequest();
                Video videoEditar = videosServico.Instanciar(editarRequest.TituloVideo, editarRequest.DescVideo, editarRequest.UrlVideo, editarRequest.Categoria);
                videoEditar.SetIdVideo(editarRequest.IdVideo.Value);

                videosServico.Editar(videoEditar);
                if (transacao.IsActive)
                    transacao.Commit();
                return mapper.Map<VideoResponse>(videoEditar);
            }
            catch (Exception e)
            {
                if (transacao.IsActive)
                    transacao.Rollback();
                throw e;
            }

        }

        public VideoIdResponse Inserir(VideoInserirRequest inserirRequest)
        {
            ITransaction transacao = session.BeginTransaction();

            try
            {
                Video videoInserir = videosServico.Instanciar(inserirRequest.TituloVideo, inserirRequest.DescVideo, inserirRequest.UrlVideo, inserirRequest.CategoriaId);

                videoInserir = videosServico.Inserir(videoInserir);
                if (transacao.IsActive)
                    transacao.Commit();
                return mapper.Map<VideoIdResponse>(videoInserir);

            }
            catch (Exception e)
            {
                if (transacao.IsActive)
                    transacao.Rollback();
                throw e;
            }
        }

        public Object Recuperar(int idVideo)
        {
            try
            {
                Video video = videosServico.Validar(idVideo);
                return mapper.Map<VideoResponse>(video);
            }
            catch (Exception e)
            {
                MensagemResponse mensagem = new MensagemResponse();
                mensagem.Mensagem = e.Message;
                return mensagem;
            }
        }
    }
}
