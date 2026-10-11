using Microsoft.AspNetCore.Mvc;
using Money.Api.Common.Api;
using Money.Core.Handlers;
using Money.Core.Requests.Relatorios;
using Money.Core.Responses;
using System.Security.Claims;

namespace Money.Api.Endpoints.Relatorios
{
    public class SelecionarReceitasVersusDespesasEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapGet("/ReceitasVersusDespesas", SelecionarReceitasVersusDespesas)
                .Produces<Response<List<SelecionarReceitasVersusDespesasRequest>?>>()
                .WithName("Relatórios: Selecionar Receitas versus Despesas")
                .WithSummary("Selecionar as receitas versus despesas existentes agrupadas por mês e ano.")
                .WithTags("Relatórios")
                .WithOrder(3);
        }

        private static async Task<IResult> SelecionarReceitasVersusDespesas(
            ClaimsPrincipal user,
            [FromServices] IRelatorioHandler handler)
        {
            var request = new SelecionarReceitasVersusDespesasRequest
            {
                CodigoUsuario = user.Identity?.Name ?? string.Empty,
            };
            var response = await handler.SelecionarReceitasVersusDespesasAsync(request);

            return response.IsSuccess
                ? TypedResults.Ok(response)
                : TypedResults.BadRequest(response);
        }
    }
}
