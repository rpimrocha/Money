using Money.Api.Common.Api;
using Money.Api.Endpoints.Categorias;
using Money.Api.Endpoints.Identity;
using Money.Api.Endpoints.Transacoes;
using Money.Api.Models;

namespace Money.Api.Endpoints
{
    public static class Endpoint
    {
        public static void MapearEndponts(this WebApplication app)
        {
            var endpoints = app.MapGroup("");

            endpoints.MapGroup("/")
                .WithTags("Teste da API")
                .MapGet("/", () => new { mensagem = "Olá Mundo!" });

            endpoints.MapGroup("v1/identity")
                .WithTags("Identity")
                .MapIdentityApi<User>();

            endpoints.MapGroup("v1/identity")
                .WithTags("Identity")
                .MapearEndpoint<LogoutEndpoint>()
                .MapearEndpoint<SelecionarRolesEndpoint>();

            endpoints.MapGroup("v1/categorias")
                .WithName("Categorias")
                .WithTags("Categorias")
                .RequireAuthorization()
                .WithOrder(1)
                .MapearEndpoint<InserirCategoriaEndpoint>()
                .MapearEndpoint<AlterarCategoriaEndpoint>()
                .MapearEndpoint<ApagarCategoriaEndpoint>()
                .MapearEndpoint<SelecionarCategoriaPorCodigoEndpoint>()
                .MapearEndpoint<SelecionarTodasCategoriasEndpoint>();

            endpoints.MapGroup("v1/transacoes")
                .WithName("Transações")
                .WithTags("Transações")
                .RequireAuthorization()
                .WithOrder(2)
                .MapearEndpoint<InserirTransacaoEndpoint>()
                .MapearEndpoint<AlterarTransacaoEndpoint>()
                .MapearEndpoint<ApagarTransacaoEndpoint>()
                .MapearEndpoint<SelecionarTransacaoPorCodigoEndpoint>()
                .MapearEndpoint<SelecionarTransacaoPorDataEndpoint>();
        }

        private static IEndpointRouteBuilder MapearEndpoint<TEndpoint>(this IEndpointRouteBuilder app)
            where TEndpoint : IEndpoint
        {
            TEndpoint.Map(app);
            return app;
        }   
    }
}
