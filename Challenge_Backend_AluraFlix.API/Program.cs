using Challenge_Backend_AluraFlix.API.Extensions;
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
using Challenge_Backend_AluraFlix.Infra.Categorias.Mapeamentos;
using Challenge_Backend_AluraFlix.Infra.Videos;
using Challenge_Backend_AluraFlix.Infra.Videos.Mapeamentos;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NHibernate;
using ISession = NHibernate.ISession;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutenticacao(builder.Configuration);
builder.Services.AddSingleton<ISessionFactory>(factory =>
{
    string connectionString = builder.Configuration.GetConnectionString("MySql");
    return Fluently.Configure()
                        .Database(MySQLConfiguration.Standard
                            .ConnectionString(connectionString)
                            .FormatSql()
                            .ShowSql())
                        .Mappings(x =>
                        {
                            x.FluentMappings.AddFromAssemblyOf<VideosMap>();
                            x.FluentMappings.AddFromAssemblyOf<CategoriasMap>();
                        })
                        .BuildSessionFactory();
});

builder.Services.AddDbContext<IdentityDataContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("MySql"),
        ServerVersion.Parse("8.0.28")
        )
);

builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<IdentityDataContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAutoMapper(typeof(VideosProfile));

builder.Services.AddSingleton<IVideosRepositorio, VideosRepositorio>();
builder.Services.AddSingleton<IVideosServico, VideosServico>();
builder.Services.AddSingleton<IVideosAppServico, VideosAppServico>();

builder.Services.AddSingleton<ICategoriasRepositorio, CategoriasRepositorio>();
builder.Services.AddSingleton<ICategoriasServico, CategoriasServico>();
builder.Services.AddSingleton<ICategoriasAppServico, CategoriasAppServico>();
builder.Services.AddSingleton<IPaginacaoAppServico, PaginacaoAppServico>();

builder.Services.AddScoped<IIdentityServico, IdentityServico>();

builder.Services.AddSingleton<ISession>(factory => factory.GetService<ISessionFactory>()?.OpenSession());



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
