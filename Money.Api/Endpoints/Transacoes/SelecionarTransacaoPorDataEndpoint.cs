using Microsoft.AspNetCore.Mvc;
using Money.Api.Common.Api;
using Money.Core;
using Money.Core.Handlers;
using Money.Core.Models;
using Money.Core.Requests.Transacoes;
using Money.Core.Responses;
using System.Security.Claims;

namespace Money.Api.Endpoints.Transacoes
{
    public class SelecionarTransacaoPorDataEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapGet("/", SelecionarTransacaoPorData)
                .Produces<PagedResponse<List<Transacao>?>>()
                .WithName("Transações: Selecionar por Data")
                .WithSummary("Selecionar uma transação existente.")
                .WithTags("Transações")
                .WithOrder(5);
        }

        private static async Task<IResult> SelecionarTransacaoPorData(
            ClaimsPrincipal user,
            [FromServices] ITransacaoHandler handler,
            [FromQuery] DateTime? dataInicial = null, 
            [FromQuery] DateTime? dataFinal = null, 
            [FromQuery] int paginaNumero = Configuracao.PaginaNumeroPadrao,
            [FromQuery] int registrosPorPagina = Configuracao.TamanhoPaginaPadrao)
        {
            var request = new SelecionarTransacaoPorDataRequest
            {
                CodigoUsuario = user.Identity?.Name ?? string.Empty,
                DataInicial = dataInicial, 
                DataFinal = dataFinal,
                PaginaNumero = paginaNumero,
                RegistrosPorPagina = registrosPorPagina
            };
            var response = await handler.SelecionarPorDataAsync(request);

            return response.IsSuccess
                ? Results.Ok(response)
                : Results.BadRequest(response);
        }
    }
}
