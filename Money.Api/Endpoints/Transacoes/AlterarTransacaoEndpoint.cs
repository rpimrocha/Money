using Microsoft.AspNetCore.Mvc;
using Money.Api.Common.Api;
using Money.Core.Handlers;
using Money.Core.Models;
using Money.Core.Requests.Transacoes;
using Money.Core.Responses;

namespace Money.Api.Endpoints.Transacoes
{
    public class AlterarTransacaoEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapPut("/{codigo}", AlterarTransacao)
                .Produces<Response<Transacao?>>()
                .WithName("Transações: Alterar")
                .WithSummary("Alterar uma transação existente.")
                .WithTags("Transações")
                .WithOrder(2);
        }

        private static async Task<IResult> AlterarTransacao(
            [FromRoute] long codigo,
            [FromBody] AlterarTransacaoRequest request,
            [FromServices] ITransacaoHandler handler)
        {
            request.CodigoUsuario = "ricardopim@msn.com";
            request.Codigo = codigo;
            var response = await handler.AlterarAsync(request);

            return response.IsSuccess
                ? Results.Ok(response)
                : Results.BadRequest(response);
        }
    }
}
