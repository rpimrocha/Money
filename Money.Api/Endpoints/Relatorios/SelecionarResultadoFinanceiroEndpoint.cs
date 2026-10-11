using Microsoft.AspNetCore.Mvc;
using Money.Api.Common.Api;
using Money.Core.Handlers;
using Money.Core.Requests.Relatorios;
using Money.Core.Responses;
using System.Security.Claims;

namespace Money.Api.Endpoints.Relatorios
{
    public class SelecionarResultadoFinanceiroEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapGet("/ResultadoFinanceiro", SelecionarResultadoFinanceiro)
                .Produces<Response<SelecionarResultadoFinanceiroRequest?>>()
                .WithName("Relatórios: Selecionar Resultado Financeiro")
                .WithSummary("Selecionar o resultado financeiro do mlês.")
                .WithTags("Relatórios")
                .WithOrder(4);
        }

        private static async Task<IResult> SelecionarResultadoFinanceiro(
            ClaimsPrincipal user,
            [FromServices] IRelatorioHandler handler)
        {
            var request = new SelecionarResultadoFinanceiroRequest
            {
                CodigoUsuario = user.Identity?.Name ?? string.Empty,
            };
            var response = await handler.SelecionarResultadoFinanceiroAsync(request);

            return response.IsSuccess
                ? TypedResults.Ok(response)
                : TypedResults.BadRequest(response);
        }
    }
}
