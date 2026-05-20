using Money.Core.Models;
using Money.Core.Requests.Categorias;
using Money.Core.Responses;

namespace Money.Core.Handlers
{
    public interface ICategoriaHandler
    {
        Task<Response<Categoria?>> InserirAsync(InserirCategoriaRequest request);
        Task<Response<Categoria?>> AlterarAsync(AlterarCategoriaRequest request);
        Task<Response<Categoria?>> ApagarAsync(ApagarCategoriaRequest request);
        Task<Response<Categoria?>> SelecionarPorCodigoAsync(SelecionarCategoriaPorCodigoRequest request);
        Task<PagedResponse<List<Categoria>>> SelecionarTodosAsync(SelecionarTodasCategoriasRequest request);
    }
}
