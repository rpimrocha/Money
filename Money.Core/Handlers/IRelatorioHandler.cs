using Money.Core.Models.Relatorios;
using Money.Core.Requests.Relatorios;
using Money.Core.Responses;

namespace Money.Core.Handlers
{
    public interface IRelatorioHandler
    {
        Task<Response<List<DespesasPorCategoria>?>> SelecionarDespesasPorCategoriaAsync(SelecionarDespesasPorCategoriaRequest request);
        Task<Response<List<ReceitasPorCategoria>?>> SelecionarReceitasPorCategoriaAsync(SelecionarReceitasPorCategoriaRequest request);
        Task<Response<List<ReceitasVersusDespesas>?>> SelecionarReceitasVersusDespesasAsync(SelecionarReceitasVersusDespesasRequest request);
        Task<Response<ResultadoFinanceiro?>> SelecionarResultadoFinanceiroAsync(SelecionarResultadoFinanceiroRequest request);
    }
}