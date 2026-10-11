using Microsoft.AspNetCore.Mvc;
using Money.Api.Common.Api;
using Money.Core.Handlers;
using Money.Core.Requests.Relatorios;
using Money.Core.Requests.Transacoes;
using Money.Core.Responses;
using System.Security.Claims;

namespace Money.Api.Endpoints.Relatorios
{
    public class SelecionarReceitasPorCategoriaEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapGet("/ReceitasPorCategoria", SelecionarReceitasPorCategoria)
                .Produces<Response<List<SelecionarReceitasPorCategoriaRequest>?>>()
                .WithName("Relatórios: Selecionar Receitas Por Categoria")
                .WithSummary("Selecionar as receitas existentes agrupadas por categoria.")
                .WithTags("Relatórios")
                .WithOrder(2);
        }

        private static async Task<IResult> SelecionarReceitasPorCategoria(
            ClaimsPrincipal user,
            [FromServices] IRelatorioHandler handler)
        {
            var request = new SelecionarReceitasPorCategoriaRequest
            {
                CodigoUsuario = user.Identity?.Name ?? string.Empty,
            };
            var response = await handler.SelecionarReceitasPorCategoriaAsync(request);

            return response.IsSuccess
                ? TypedResults.Ok(response)
                : TypedResults.BadRequest(response);
        }
    }
}
