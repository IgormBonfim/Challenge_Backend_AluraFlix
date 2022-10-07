using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Backend_AluraFlix.Ioc.Extensions
{
    public static class ConfiguracoesCors
    {
        public static void ConfiguraCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                string dominio = "http://localhost:4200";
                options.AddDefaultPolicy(builder => builder.WithOrigins(dominio)
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                );
            });
        }
    }
}
