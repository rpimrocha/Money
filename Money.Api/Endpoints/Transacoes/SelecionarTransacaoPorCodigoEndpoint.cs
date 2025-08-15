using Microsoft.AspNetCore.Mvc;
using Money.Api.Common.Api;
using Money.Core.Handlers;
using Money.Core.Models;
using Money.Core.Requests.Transacoes;
using Money.Core.Responses;
using System.Security.Claims;

namespace Money.Api.Endpoints.Transacoes
{
    public class SelecionarTransacaoPorCodigoEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapGet("/{codigo}", SelecionarTransacaoPorCodigo)
                .Produces<Response<Transacao?>>()
                .WithName("Transações: Selecionar por Código")
                .WithSummary("Selecionar uma transação existente.")
                .WithTags("Transações")
                .WithOrder(4);
        }

        private static async Task<IResult> SelecionarTransacaoPorCodigo(
            ClaimsPrincipal user,
            [FromRoute] long codigo,
            [FromServices] ITransacaoHandler handler)
        {
            var request = new SelecionarTransacaoPorCodigoRequest
            {
                CodigoUsuario = user.Identity?.Name ?? string.Empty,
                Codigo = codigo
            };
            var response = await handler.SelecionarPorCodigoAsync(request);

            return response.IsSuccess
                ? Results.Ok(response)
                : Results.BadRequest(response);
        }
    }
}
