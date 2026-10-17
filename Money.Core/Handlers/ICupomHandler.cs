using Money.Core.Models;
using Money.Core.Requests.Cupons;
using Money.Core.Responses;

namespace Money.Core.Handlers
{
    public interface ICupomHandler
    {
        Task<Response<Cupom?>> SelecionarPorReferenciaAsync(SelecionarCupomPorNumeroRequest request);
    }
}
