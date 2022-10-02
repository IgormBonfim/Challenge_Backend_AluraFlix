using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Challenge_Backend_AluraFlix.Aplicacao.Categorias.Servicos;
using Challenge_Backend_AluraFlix.Aplicacao.Categorias.Servicos.Interfaces;
using Challenge_Backend_AluraFlix.Aplicacao.Usuarios.Servicos.Interfaces;
using Challenge_Backend_AluraFlix.Aplicacao.Paginacao.Servicos;
using Challenge_Backend_AluraFlix.Aplicacao.Paginacao.Servicos.Interfaces;
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
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NHibernate;
using ISession = NHibernate.ISession;
using Challenge_Backend_AluraFlix.Ioc.Extensions;
using MailKit.Net.Smtp;
using Challenge_Backend_AluraFlix.Autenticacao.Configuracoes;
using Challenge_Backend_AluraFlix.Autenticacao.Servicos.Interfaces;
using Challenge_Backend_AluraFlix.Aplicacao.Usuarios.Servicos;

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
                                    .Mappings(x => x.FluentMappings.AddFromAssemblyOf<VideosMap>())
                                    .BuildSessionFactory();
            });

            services.AddDbContext<IdentityDataContext>(options =>
                    options.UseMySql(
                    configuration.GetConnectionString("MySql"),
                    ServerVersion.Parse("8.0.28")
                )
            );

            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<IdentityDataContext>()
                .AddDefaultTokenProviders();

            services.AddAutoMapper(typeof(VideosProfile));

            services.AddSingleton<IVideosRepositorio, VideosRepositorio>();
            services.AddSingleton<IVideosServico, VideosServico>();
            services.AddSingleton<IVideosAppServico, VideosAppServico>();
            
            services.AddSingleton<ICategoriasRepositorio, CategoriasRepositorio>();
            services.AddSingleton<ICategoriasServico, CategoriasServico>();
            services.AddSingleton<ICategoriasAppServico, CategoriasAppServico>();
            services.AddSingleton<IPaginacaoAppServico, PaginacaoAppServico>();

            services.AddScoped<IUsuarioAppServico, UsuarioAppServico>();
            services.AddScoped<IEmailServico, EmailServico>();
            services.AddScoped<ISmtpClient, SmtpClient>();
            services.AddScoped<IIdentityServico, IdentityServico>();

            services.AddSingleton<ISession>(factory => factory.GetService<ISessionFactory>()?.OpenSession());

        }
    }
}
