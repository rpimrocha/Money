using Microsoft.AspNetCore.Mvc;
using Money.Api.Common.Api;
using Money.Core;
using Money.Core.Handlers;
using Money.Core.Models;
using Money.Core.Requests.Categorias;
using Money.Core.Responses;
using System.Security.Claims;

namespace Money.Api.Endpoints.Categorias
{
    public class SelecionarTodasCategoriasEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapGet("/", SelecionarTodasCategorias)
                .Produces<PagedResponse<List<Categoria>?>>()
                .WithName("Categorias: Selecionar Todas")
                .WithSummary("Selecionar todas categorias existentes.")
                .WithTags("Categorias")
                .WithOrder(5);
        }

        private static async Task<IResult> SelecionarTodasCategorias(
            ClaimsPrincipal user,
            [FromServices] ICategoriaHandler handler,
            [FromQuery] int paginaNumero = Configuracao.PaginaNumeroPadrao,
            [FromQuery] int registrosPorPagina = Configuracao.TamanhoPaginaPadrao)
        {
            var request = new SelecionarTodasCategoriasRequest
            {
                CodigoUsuario = user.Identity?.Name ?? string.Empty,
                PaginaNumero = paginaNumero,
                RegistrosPorPagina = registrosPorPagina
            };
            var response = await handler.SelecionarTodosAsync(request);

            return response.IsSuccess
                ? Results.Ok(response)
                : Results.BadRequest(response);
        }
    }
}
