using Money.Api.Common.Api;
using Money.Api.Endpoints.Categorias;
using Money.Api.Endpoints.Transacoes;

namespace Money.Api.Endpoints
{
    public static class Endpoint
    {
        public static void MapEndponts(this WebApplication app)
        {
            var endpoints = app.MapGroup("");

            endpoints.MapGroup("v1/categorias")
                .WithName("Categorias")
                .WithTags("Categorias")
                //.RequireAuthorization()
                .WithOrder(1)
                .MapEndpoint<InserirCategoriaEndpoint>()
                .MapEndpoint<AlterarCategoriaEndpoint>()
                .MapEndpoint<ApagarCategoriaEndpoint>()
                .MapEndpoint<SelecionarCategoriaPorCodigoEndpoint>()
                .MapEndpoint<SelecionarTodasCategoriasEndpoint>();

            endpoints.MapGroup("v1/transacoes")
                .WithName("Transações")
                .WithTags("Transações")
                //.RequireAuthorization()
                .WithOrder(2)
                .MapEndpoint<InserirTransacaoEndpoint>()
                .MapEndpoint<AlterarTransacaoEndpoint>()
                .MapEndpoint<ApagarTransacaoEndpoint>()
                .MapEndpoint<SelecionarTransacaoPorCodigoEndpoint>()
                .MapEndpoint<SelecionarTransacaoPorDataEndpoint>();
        }

        private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app)
            where TEndpoint : IEndpoint
        {
            TEndpoint.Map(app);
            return app;
        }   
    }
}
