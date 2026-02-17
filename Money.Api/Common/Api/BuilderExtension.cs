using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Money.Api.Data;
using Money.Api.Handlers;
using Money.Api.Models;
using Money.Core;
using Money.Core.Handlers;

namespace Money.Api.Common.Api
{
    public static class BuilderExtension
    {
        public static void AdicionarConfiguracao(this WebApplicationBuilder builder)
        {
            Configuracao.StringDeConexao = builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
            Configuracao.UrlDoBackend = builder.Configuration.GetValue<string>("BackendUrl") ?? string.Empty;
            Configuracao.UrlDoFrontend = builder.Configuration.GetValue<string>("FrontendUrl") ?? string.Empty;
            Configuracao.NomeDaPoliticaDoCors = builder.Configuration.GetValue<string>("CorsPolicyName") ?? string.Empty;
        }

        public static void AdicionarSeguranca(this WebApplicationBuilder builder)
        {
            builder.Services.AddAuthentication(IdentityConstants.ApplicationScheme).AddIdentityCookies();
            builder.Services.AddAuthorization();
        }

        public static void AdicionarDataContexts(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(Configuracao.StringDeConexao));

            builder.Services.AddIdentityCore<User>().AddRoles<IdentityRole<long>>()
                .AddEntityFrameworkStores<AppDbContext>().AddApiEndpoints();
        }

        public static void AdicionarCrossOrigin(this WebApplicationBuilder builder)
        {
            builder.Services.AddCors(option =>
            {
                option.AddPolicy(Configuracao.NomeDaPoliticaDoCors, policy =>
                {
                    policy.WithOrigins(Configuracao.UrlDoFrontend)
                    .WithOrigins([
                        Configuracao.UrlDoBackend,
                        Configuracao.UrlDoFrontend
                    ])
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
                });
            });
        }

        public static void AdicionarSwagger(this WebApplicationBuilder builder)
        {
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(x => { x.CustomSchemaIds(n => n.FullName); });
        }

        public static void AdicionarServicos(this WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<ICategoriaHandler, CategoriaHandler>();
            builder.Services.AddTransient<ITransacaoHandler, TransacaoHandler>();
        }
    }
}