using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Challenge_Backend_AluraFlix.Aplicacao.Categorias.Servicos;
using Challenge_Backend_AluraFlix.Aplicacao.Categorias.Servicos.Interfaces;
using Challenge_Backend_AluraFlix.Aplicacao.Usuarios.Servicos.Interfaces;
using Challenge_Backend_AluraFlix.Aplicacao.Videos.Profiles;
using Challenge_Backend_AluraFlix.Aplicacao.Videos.Servicos;
using Challenge_Backend_AluraFlix.Aplicacao.Videos.Servicos.Interfaces;
using Challenge_Backend_AluraFlix.Autenticacao.Data;
using Challenge_Backend_AluraFlix.Autenticacao.Servicos;
using Challenge_Backend_AluraFlix.Dominio.Categorias.Repositorios;
using Challenge_Backend_AluraFlix.Dominio.Categorias.Servicos;
using Challenge_Backend_AluraFlix.Dominio.Categorias.Servicos.Interfaces;
using Challenge_Backend_AluraFlix.Dominio.Videos.Repositorios;
using Challenge_Backend_AluraFlix.Dominio.Videos.Servicos;
using Challenge_Backend_AluraFlix.Dominio.Videos.Servicos.Interfaces;
using Challenge_Backend_AluraFlix.Infra.Categorias;
using Challenge_Backend_AluraFlix.Infra.Videos;
using Challenge_Backend_AluraFlix.Infra.Videos.Mapeamentos;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.EntityFrameworkCore;
using NHibernate;
using ISession = NHibernate.ISession;
using Challenge_Backend_AluraFlix.Ioc.Extensions;
using MailKit.Net.Smtp;
using Challenge_Backend_AluraFlix.Autenticacao.Configuracoes;
using Challenge_Backend_AluraFlix.Autenticacao.Servicos.Interfaces;
using Challenge_Backend_AluraFlix.Aplicacao.Usuarios.Servicos;
using Challenge_Backend_AluraFlix.Dominio.Usuarios.Repositorios;
using Challenge_Backend_AluraFlix.Infra.Usuarios;
using Challenge_Backend_AluraFlix.Dominio.Usuarios.Servicos;
using Challenge_Backend_AluraFlix.Dominio.Usuarios.Servicos.Interfaces;
using Challenge_Backend_AluraFlix.Aplicacao.Favoritos.Servicos;
using Challenge_Backend_AluraFlix.Aplicacao.Favoritos.Servicos.Interfaces;
using Challenge_Backend_AluraFlix.Dominio.Favoritos.Servicos;
using Challenge_Backend_AluraFlix.Dominio.Favoritos.Servicos.Interfaces;
using Challenge_Backend_AluraFlix.Aplicacao.Genericos.Servicos.Interfaces;
using Challenge_Backend_AluraFlix.Aplicacao.Genericos.Servicos;
using FluentNHibernate.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity;
using Challenge_Backend_AluraFlix.Autenticacao.Entidades;
using Challenge_Backend_AluraFlix.Autenticacao.Mapeamentos;
using FluentNHibernate.AspNetCore.Identity.Mappings;

namespace Challenge_Backend_AluraFlix.Ioc
{
    public static class InjetorDeDependencias
    {
        public static void InjetarDependecias(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutenticacao(configuration);

            services.AddSingleton<ISessionFactory>(factory =>
            {
                string connectionString = configuration.GetConnectionString("MySql");
            return Fluently.Configure()
                                .Database(MySQLConfiguration.Standard
                                    .ConnectionString(connectionString)
                                    .FormatSql()
                                    .ShowSql())
                                .Mappings(x => {
                                    x.FluentMappings.AddFromAssemblyOf<VideosMap>();
                                    x.FluentMappings.AddFromAssemblyOf<ApplicationUserMap>()
                                    .Add<IdentityRoleClaimMap>()
                                    .Add<IdentityUserLoginMap>();
                                    })
                                    .BuildSessionFactory();
            });

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .ExtendConfiguration()
                .AddRoles<ApplicationRole>()
                .AddUserRole<ApplicationUserRole>()
                .AddNHibernateStores(t => t.SetSessionAutoFlush(false))
                .AddDefaultTokenProviders();

            //services.AddIdentityCore<ApplicationUser>()
            //    .ExtendConfiguration()
            //    .AddRoles<ApplicationRole>()
            //    .AddUserRole<ApplicationUserRole>()
            //    .AddNHibernateStores(t => t.SetSessionAutoFlush(false))
            //    .AddDefaultTokenProviders();


            services.AddAutoMapper(typeof(VideosProfile));

            services.AddScoped<IVideosRepositorio, VideosRepositorio>();
            services.AddScoped<IVideosServico, VideosServico>();
            services.AddScoped<IVideosAppServico, VideosAppServico>();

            services.AddScoped<IFavoritosServico, FavoritosServico>();
            services.AddScoped<IFavoritosAppServico, FavoritosAppServico>();
            
            services.AddScoped<ICategoriasRepositorio, CategoriasRepositorio>();
            services.AddScoped<ICategoriasServico, CategoriasServico>();
            services.AddScoped<ICategoriasAppServico, CategoriasAppServico>();

            services.AddScoped<IUsuario, Usuario>();
            services.AddScoped<IUsuariosRepositorio, UsuariosRepositorio>();
            services.AddScoped<IUsuariosServico, UsuariosServico>();
            services.AddScoped<IUsuariosAppServico, UsuariosAppServico>();
            services.AddScoped<IEmailServico, EmailServico>();
            services.AddScoped<ISmtpClient, SmtpClient>();
            services.AddScoped<IIdentityServico, IdentityServico>();

            services.AddScoped<ISession>(factory => factory.GetService<ISessionFactory>()!.OpenSession());

        }
    }
}
