using Microsoft.AspNetCore.Mvc;
using Money.Api.Common.Api;
using Money.Core.Handlers;
using Money.Core.Models;
using Money.Core.Requests.Categorias;
using Money.Core.Responses;

namespace Money.Api.Endpoints.Categorias
{
    public class SelecionarCategoriaPorCodigoEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapGet("/{codigo}", SelecionarCategoriaPorCodigo)
                .Produces<Response<Categoria?>>()
                .WithName("Categorias: Selecionar por Código")
                .WithSummary("Selecionar uma categoria existente.")
                .WithTags("Categorias")
                .WithOrder(4);
        }

        private static async Task<IResult> SelecionarCategoriaPorCodigo(
            [FromRoute] long codigo,
            [FromServices] ICategoriaHandler handler)
        {
            var request = new SelecionarCategoriaPorCodigoRequest
            {
                CodigoUsuario = "ricardopim@msn.com",
                Codigo = codigo
            };
            var response = await handler.SelecionarPorCodigoAsync(request);

            return response.IsSuccess
                ? Results.Ok(response)
                : Results.BadRequest(response);
        }
    }
}
