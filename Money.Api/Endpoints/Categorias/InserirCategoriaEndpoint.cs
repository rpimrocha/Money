using Microsoft.AspNetCore.Mvc;
using Money.Api.Common.Api;
using Money.Core.Handlers;
using Money.Core.Models;
using Money.Core.Requests.Categorias;
using Money.Core.Responses;

namespace Money.Api.Endpoints.Categorias
{
    public class InserirCategoriaEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapPost("/", InserirCategoria)
                .Produces<Response<Categoria?>>()
                .WithName("Categorias: Inserir")
                .WithSummary("Inserir uma nova categoria.")
                .WithTags("Categorias")
                .WithOrder(1);
        }

        private static async Task<IResult> InserirCategoria(
            [FromBody] InserirCategoriaRequest request,
            [FromServices] ICategoriaHandler handler)
        {
            request.CodigoUsuario = "ricardopim@msn.com";
            var response = await handler.InserirAsync(request);

            return response.IsSuccess
                ? Results.Created($"/{response.Dado?.Codigo}.", response)
                : Results.BadRequest(response);
        }
    }
}
