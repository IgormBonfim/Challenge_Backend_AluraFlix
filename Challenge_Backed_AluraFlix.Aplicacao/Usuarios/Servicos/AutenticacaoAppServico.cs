using Challenge_Backend_AluraFlix.Aplicacao.Usuarios.Servicos.Interfaces;
using Challenge_Backend_AluraFlix.DataTransfer.Usuarios.Requests;
using Challenge_Backend_AluraFlix.DataTransfer.Usuarios.Responses;
using Challenge_Backend_AluraFlix.Dominio.Usuarios.Repositorios;
using Challenge_Backend_AluraFlix.Dominio.Usuarios.Servicos.Interfaces;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Backend_AluraFlix.Aplicacao.Usuarios.Servicos
{
    public class AutenticacaoAppServico : IAutenticacaoAppServico
    {
        private readonly IGeradorTokenJwt tokenJwt;
        private readonly ISession session;
        private readonly IUsuariosServico usuariosServico;
        private readonly IUsuariosRepositorio usuariosRepositorio;

        public AutenticacaoAppServico(IGeradorTokenJwt tokenJwt, ISession session, IUsuariosServico usuariosServico, IUsuariosRepositorio usuariosRepositorio)
        {
            this.tokenJwt = tokenJwt;
            this.session = session;
            this.usuariosServico = usuariosServico;
            this.usuariosRepositorio = usuariosRepositorio;
        }
        public AutenticacaoResponse Login(UsuarioLoginRequest usuarioLoginRequest)
        {
            try
            {
                var query = usuariosRepositorio.Buscar()
                    .Where(x => x.EmailUsuario == usuarioLoginRequest.EmailUsuario)
                    .Where(x => x.SenhaUsuario == usuarioLoginRequest.SenhaUsuario);

                var usuario = usuariosServico.Validar(query);

                string tokenGerado = tokenJwt.GerarToken(usuario.IdUsuario, usuario.NomeUsuario, usuario.SobrenomeUsuario);

                var response = new AutenticacaoResponse
                {
                    IdUsuario = usuario.IdUsuario,
                    NomeUsuario = usuario.NomeUsuario,
                    SobrenomeUsuario = usuario.SobrenomeUsuario,
                    EmailUsuario = usuario.EmailUsuario,
                    Token = tokenGerado
                };

                return response;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public AutenticacaoResponse Registrar(UsuarioRegistrarRequest usuarioRegistrarRequest)
        {
            ITransaction transacao = session.BeginTransaction();

            try
            {
                var novoUsuario = usuariosServico.Instanciar(usuarioRegistrarRequest.NomeUsuario, usuarioRegistrarRequest.SobrenomeUsuario, usuarioRegistrarRequest.EmailUsuario, usuarioRegistrarRequest.SenhaUsuario);
                var usuario = usuariosServico.Inserir(novoUsuario);

                string tokenGerado = tokenJwt.GerarToken(usuario.IdUsuario, usuario.NomeUsuario, usuario.SobrenomeUsuario);

                if (transacao.IsActive)
                    transacao.Commit();

                var response = new AutenticacaoResponse
                {
                    IdUsuario = usuario.IdUsuario,
                    NomeUsuario = usuario.NomeUsuario,
                    SobrenomeUsuario = usuario.SobrenomeUsuario,
                    EmailUsuario = usuario.EmailUsuario,
                    Token = tokenGerado
                };

                return response;
            }
            catch (Exception e)
            {
                if (transacao.IsActive)
                    transacao.Rollback();
                throw e;
            }

            
        }
    }
}
