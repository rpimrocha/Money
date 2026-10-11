using Microsoft.AspNetCore.Mvc;
using Money.Api.Common.Api;
using Money.Core.Handlers;
using Money.Core.Requests.Relatorios;
using Money.Core.Requests.Transacoes;
using Money.Core.Responses;
using System.Security.Claims;

namespace Money.Api.Endpoints.Relatorios
{
    public class SelecionarDespesasPorCategoriaEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapGet("/DespesasPorCategoria", SelecionarDespesasPorCategoria)
                .Produces<Response<List<SelecionarDespesasPorCategoriaRequest>?>>()
                .WithName("Relatórios: Selecionar Despesas Por Categoria")
                .WithSummary("Selecionar as despesas existentes agrupadas por categoria.")
                .WithTags("Relatórios")
                .WithOrder(1);
        }

        private static async Task<IResult> SelecionarDespesasPorCategoria(
            ClaimsPrincipal user,
            [FromServices] IRelatorioHandler handler)
        {
            var request = new SelecionarDespesasPorCategoriaRequest
            {
                CodigoUsuario = user.Identity?.Name ?? string.Empty,
            };
            var response = await handler.SelecionarDespesasPorCategoriaAsync(request);

            return response.IsSuccess
                ? TypedResults.Ok(response)
                : TypedResults.BadRequest(response);
        }
    }
}
