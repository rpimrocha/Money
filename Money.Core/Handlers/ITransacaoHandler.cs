using Money.Core.Models;
using Money.Core.Requests.Transacoes;
using Money.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money.Core.Handlers
{
    public interface ITransacaoHandler
    {
        Task<Response<Transacao?>> InserirAsync(InserirTransacaoRequest request);
        Task<Response<Transacao?>> AlterarAsync(AlterarTransacaoRequest request);
        Task<Response<Transacao?>> ApagarAsync(ApagarTransacaoRequest request);
        Task<Response<Transacao?>> SelecionarPorCodigoAsync(SelecionarTransacaoPorCodigoRequest request);
        Task<PagedResponse<List<Transacao>>> SelecionarPorDataAsync(SelecionarTransacaoPorDataRequest request);
    }
}
