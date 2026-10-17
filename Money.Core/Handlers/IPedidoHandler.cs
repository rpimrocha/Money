using Money.Core.Models;
using Money.Core.Requests.Pedidos;
using Money.Core.Responses;

namespace Money.Core.Handlers
{
    public interface IPedidoHandler
    {
        Task<Response<Produto?>> InserirAsync(InserirPedidoRequest request);
        Task<Response<Produto?>> CancelarAsync(CancelarPedidoRequest request);
        Task<Response<Produto?>> PagarAsync(PagarPedidoRequest request);
        Task<Response<Produto?>> EstornarAsync(EstornarPedidoRequest request);
        Task<Response<Produto?>> SelecionarPorNumeroAsync(SelecionarPedidoPorNumeroRequest request);
        Task<PagedResponse<List<Produto>?>> SelecionarTodosAsync(SelecionarTodosPedidosRequest request);
    }
}
