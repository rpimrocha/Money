using Microsoft.AspNetCore.Mvc;
using Money.Api.Common.Api;
using Money.Core.Handlers;
using Money.Core.Models;
using Money.Core.Requests.Categorias;
using Money.Core.Responses;

namespace Money.Api.Endpoints.Categorias
{
    public class AlterarCategoriaEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapPut("/{codigo}", AlterarCategoria)
                .Produces<Response<Categoria?>>()
                .WithName("Categorias: Alterar")
                .WithSummary("Alterar uma categoria existente.")
                .WithTags("Categorias")
                .WithOrder(2);
        }

        private static async Task<IResult> AlterarCategoria(
            [FromRoute] long codigo,
            [FromBody] AlterarCategoriaRequest request,
            [FromServices] ICategoriaHandler handler)
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
