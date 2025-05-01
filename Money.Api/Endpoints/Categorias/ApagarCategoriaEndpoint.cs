using Microsoft.AspNetCore.Mvc;
using Money.Api.Common.Api;
using Money.Core.Handlers;
using Money.Core.Models;
using Money.Core.Requests.Categorias;
using Money.Core.Responses;

namespace Money.Api.Endpoints.Categorias
{
    public class ApagarCategoriaEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapDelete("/{codigo}", ApagarCategoria)
                .Produces<Response<Categoria?>>()
                .WithName("Categorias: Apagar")
                .WithSummary("Apagar uma categoria existente.")
                .WithTags("Categorias")
                .WithOrder(3);
        }

        private static async Task<IResult> ApagarCategoria(
            [FromRoute] long codigo,
            [FromServices] ICategoriaHandler handler)
        {
            var request = new ApagarCategoriaRequest
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
