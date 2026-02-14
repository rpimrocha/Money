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
        public static void AdicionarAuthentication(this WebApplicationBuilder builder)
        {
            Configuracao.StringDeConexao = builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
        }

        public static void AdicionarSecurity(this WebApplicationBuilder builder)
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

        }

        public static void AdicionarSwagger(this WebApplicationBuilder builder)
        {
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(x => { x.CustomSchemaIds(n => n.FullName); });
        }

        public static void AdicionarServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<ICategoriaHandler, CategoriaHandler>();
            builder.Services.AddTransient<ITransacaoHandler, TransacaoHandler>();
        }
    }
}
