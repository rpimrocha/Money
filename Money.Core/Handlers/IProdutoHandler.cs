using Money.Core.Models;
using Money.Core.Requests.Produtos;
using Money.Core.Responses;

namespace Money.Core.Handlers
{
    public interface IProdutoHandler
    {
        Task<Response<Produto?>> SelecionarPorReferenciaAsync(SelecionarProdutoPorReferenciaRequest request);
        Task<PagedResponse<List<Produto>?>> SelecionarTodosAsync(SelecionarTodosProdutosRequest request);
    }
}
