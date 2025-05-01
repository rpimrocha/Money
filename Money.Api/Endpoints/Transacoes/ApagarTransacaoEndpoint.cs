using Microsoft.AspNetCore.Mvc;
using Money.Api.Common.Api;
using Money.Core.Handlers;
using Money.Core.Models;
using Money.Core.Requests.Transacoes;
using Money.Core.Responses;

namespace Money.Api.Endpoints.Transacoes
{
    public class ApagarTransacaoEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapDelete("/{codigo}", ApagarTransacao)
                .Produces<Response<Transacao?>>()
                .WithName("Transações: Apagar")
                .WithSummary("Apagar uma transação existente.")
                .WithTags("Transações")
                .WithOrder(3);
        }

        private static async Task<IResult> ApagarTransacao(
            [FromRoute] long codigo,
            [FromServices] ITransacaoHandler handler)
        {
            var request = new ApagarTransacaoRequest
            {
                CodigoUsuario = "ricardopim@msn.com",
                Codigo = codigo
            };
            var response = await handler.ApagarAsync(request);

            return response.IsSuccess
                ? Results.Ok(response)
                : Results.BadRequest(response);
        }
    }
}
