using AutoMapper;
using Challenge_Backed_AluraFlix.Aplicacao.Videos.Servicos.Interfaces;
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

        public IList<VideoResponse> Buscar(string busca)
        {
            try
            {
                IList<Video> videosDb = videosServico.Buscar(busca);;

                IList<VideoResponse> videosRetorno = mapper.Map<IList<VideoResponse>>(videosDb);

                return videosRetorno;
            }
            catch
            {
                return null;
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

        public IList<VideoResponse> ListarTodos()
        {
            try
            {
                IList<Video> videosDb = videosServico.Videos();

                IList<VideoResponse> videosRetorno = mapper.Map<IList<VideoResponse>>(videosDb);

                return videosRetorno;
            }
            catch
            {
                return null;
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
