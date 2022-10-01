using AutoMapper;
using Challenge_Backend_AluraFlix.Aplicacao.Categorias.Servicos.Interfaces;
using Challenge_Backend_AluraFlix.Aplicacao.Videos.Servicos.Interfaces;
using Challenge_Backend_AluraFlix.DataTransfer.Categorias.Requests;
using Challenge_Backend_AluraFlix.DataTransfer.Categorias.Responses;
using Challenge_Backend_AluraFlix.DataTransfer.Genericos.Responses;
using Challenge_Backend_AluraFlix.DataTransfer.Videos.Requests;
using Challenge_Backend_AluraFlix.DataTransfer.Videos.Responses;
using Challenge_Backend_AluraFlix.Dominio.Categorias.Entidades;
using Challenge_Backend_AluraFlix.Dominio.Categorias.Servicos.Interfaces;
using Challenge_Backend_AluraFlix.Dominio.Videos.Entidades;
using Challenge_Backend_AluraFlix.Dominio.Videos.Servicos.Interfaces;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Backend_AluraFlix.Aplicacao.Categorias.Servicos
{
    public class CategoriasAppServico : ICategoriasAppServico
    {
        private readonly ICategoriasServico categoriasServico;
        private readonly IVideosAppServico videosAppServico;
        private readonly ISession session;
        private readonly IMapper mapper;

        public CategoriasAppServico(ICategoriasServico categoriasServico, IVideosAppServico videosAppServico, ISession session, IMapper mapper)
        {
            this.categoriasServico = categoriasServico;
            this.videosAppServico = videosAppServico;
            this.session = session;
            this.mapper = mapper;
        }

        public IList<CategoriaResponse> Buscar(CategoriaBuscarRequest buscarRequest)
        {
            try
            {
                var query = categoriasServico.Query();

                if (buscarRequest.TituloCategoria != null)
                {
                    query = query.Where(x => x.TituloCategoria.Contains(buscarRequest.TituloCategoria));
                }
                if (buscarRequest.CorCategoria != null)
                {
                    query = query.Where(x => x.CorCategoria == buscarRequest.CorCategoria);
                }

                IList<Categoria> categoriasList = categoriasServico.Buscar(query);

                return mapper.Map<IList<CategoriaResponse>>(categoriasList);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public MensagemResponse Deletar(int idCategoria)
        {
            ITransaction transacao = session.BeginTransaction();

            MensagemResponse retorno = new MensagemResponse();

            try
            {
                categoriasServico.Deletar(idCategoria);
                if (transacao.IsActive)
                    transacao.Commit();
                retorno.Mensagem = "Categoria deletada com sucesso!";
                return retorno;
            }
            catch (Exception e)
            {
                retorno.Mensagem = e.Message;
                return retorno;
            }
        }

        public CategoriaIdResponse Editar(CategoriaEditarRequest editarRequest)
        {
            editarRequest = editarRequest ?? new CategoriaEditarRequest();
            Categoria editarCategoria = mapper.Map<Categoria>(editarRequest);

            ITransaction transacao = session.BeginTransaction();

            try
            {
                categoriasServico.Editar(editarCategoria);
                if (transacao.IsActive)
                    transacao.Commit();
                return mapper.Map<CategoriaIdResponse>(editarCategoria);
            }
            catch (Exception e)
            {
                if (transacao.IsActive)
                    transacao.Rollback();
                throw e;
            }
        }

        public CategoriaIdResponse Inserir(CategoriaInserirRequest inserirRequest)
        {
            Categoria inserirCategoria = categoriasServico.Instanciar(inserirRequest.TituloCategoria, inserirRequest.CorCategoria);

            ITransaction transacao = session.BeginTransaction();

            try
            {
                inserirCategoria = categoriasServico.Inserir(inserirCategoria);
                if (transacao.IsActive)
                    transacao.Commit();
                return mapper.Map<CategoriaIdResponse>(inserirCategoria);
            }
            catch
            {
                if (transacao.IsActive)
                    transacao.Rollback();
                return null;
            }
        }

        public IList<VideoResponse> ListarPorCategoria(int id)
        {
            try
            {
                Categoria categoria = categoriasServico.Validar(id);

                VideoBuscarRequest request = new VideoBuscarRequest();
                request.CategoriaId = categoria.IdCategoria;
                return videosAppServico.Buscar(request);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public Object Recuperar(int idCategoria)
        {
            try
            {
                Categoria categoria = categoriasServico.Validar(idCategoria);
                return mapper.Map<CategoriaResponse>(categoria);
            }
            catch (Exception e)
            {
                return new MensagemResponse() { Mensagem = e.Message };
            }
        }
    }
}
