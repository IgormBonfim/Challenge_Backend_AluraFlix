﻿using AutoMapper;
using Challenge_Backed_AluraFlix.Aplicacao.Categorias.Servicos.Interfaces;
using Challenge_Backend_AluraFlix.DataTransfer.Categorias.Requests;
using Challenge_Backend_AluraFlix.DataTransfer.Categorias.Responses;
using Challenge_Backend_AluraFlix.DataTransfer.Genericos.Responses;
using Challenge_Backend_AluraFlix.Dominio.Categorias.Entidades;
using Challenge_Backend_AluraFlix.Dominio.Categorias.Servicos.Interfaces;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Backed_AluraFlix.Aplicacao.Categorias.Servicos
{
    public class CategoriasAppServico : ICategoriasAppServico
    {
        private readonly ICategoriasServico categoriasServico;
        private readonly ISession session;
        private readonly IMapper mapper;

        public CategoriasAppServico(ICategoriasServico categoriasServico, ISession session, IMapper mapper)
        {
            this.categoriasServico = categoriasServico;
            this.session = session;
            this.mapper = mapper;
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

        public IList<CategoriaResponse> ListarTodos()
        {
            try
            {
                IList<Categoria> categoriasDb = categoriasServico.Listar();
                IList<CategoriaResponse> categorias = new List<CategoriaResponse>();

                foreach (var categoria in categoriasDb)
                {
                    var categoriaResponse = mapper.Map<CategoriaResponse>(categoria);
                    categorias.Add(categoriaResponse);
                }
                return categorias;
            }
            catch
            {
                return null;
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