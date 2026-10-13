using Money.Core.Handlers;
using Money.Core.Models;
using Money.Core.Models.Relatorios;
using Money.Core.Requests.Relatorios;
using Money.Core.Responses;
using System.Net.Http.Json;

namespace Money.Web.Handlers
{
    public class RelatorioHandler(IHttpClientFactory httpClientFactory) : IRelatorioHandler
    {
        private readonly HttpClient _httpClient = httpClientFactory.CreateClient(Configuracao.HttpClientName);

        public async Task<Response<List<DespesasPorCategoria>?>> SelecionarDespesasPorCategoriaAsync(SelecionarDespesasPorCategoriaRequest request)
        {
            return await _httpClient.GetFromJsonAsync<Response<List<DespesasPorCategoria>?>>("v1/relatorios/DespesasPorCategoria")
                ?? new Response<List<DespesasPorCategoria>?> (null, 400, "Não foi possível obter as despesas por categoria.");
        }

        public async Task<Response<List<ReceitasPorCategoria>?>> SelecionarReceitasPorCategoriaAsync(SelecionarReceitasPorCategoriaRequest request)
        {
            return await _httpClient.GetFromJsonAsync<Response<List<ReceitasPorCategoria>?>>("v1/relatorios/ReceitasPorCategoria")
                ?? new Response<List<ReceitasPorCategoria>?>(null, 400, "Não foi possível obter as receitas por categoria.");
        }

        public async Task<Response<List<ReceitasVersusDespesas>?>> SelecionarReceitasVersusDespesasAsync(SelecionarReceitasVersusDespesasRequest request)
        {
            return await _httpClient.GetFromJsonAsync<Response<List<ReceitasVersusDespesas>?>>("v1/relatorios/ReceitasVersusDespesas")
                ?? new Response<List<ReceitasVersusDespesas>?>(null, 400, "Não foi possível obter as receitas versus despesas.");
        }

        public async Task<Response<ResultadoFinanceiro?>> SelecionarResultadoFinanceiroAsync(SelecionarResultadoFinanceiroRequest request)
        {
            return await _httpClient.GetFromJsonAsync<Response<ResultadoFinanceiro?>>("v1/relatorios/ResultadoFinanceiro")
                ?? new Response<ResultadoFinanceiro?>(null, 400, "Não foi possível obter o resultado financeiro.");
        }
    }
}
