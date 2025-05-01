using Microsoft.AspNetCore.Mvc;
using Money.Api.Common.Api;
using Money.Core.Handlers;
using Money.Core.Models;
using Money.Core.Requests.Transacoes;
using Money.Core.Responses;

namespace Money.Api.Endpoints.Transacoes
{
    public class InserirTransacaoEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapPost("/", InserirTransacao)
                .Produces<Response<Transacao?>>()
                .WithName("Transações: Inserir")
                .WithSummary("Inserir uma nova trasação.")
                .WithTags("Transações")
                .WithOrder(1);
        }

        private static async Task<IResult> InserirTransacao(
            [FromBody] InserirTransacaoRequest request,
            [FromServices] ITransacaoHandler handler)
        {
            request.CodigoUsuario = "ricardopim@msn.com";
            var response = await handler.InserirAsync(request);

            return response.IsSuccess
                ? Results.Created($"/{response.Dado?.Codigo}.", response)
                : Results.BadRequest(response);
        }
    }
}
