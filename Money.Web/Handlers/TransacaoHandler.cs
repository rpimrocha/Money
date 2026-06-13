using Money.Core.Common.Extensions;
using Money.Core.Handlers;
using Money.Core.Models;
using Money.Core.Requests.Categorias;
using Money.Core.Requests.Transacoes;
using Money.Core.Responses;
using System.Net.Http.Json;
using System.Transactions;

namespace Money.Web.Handlers
{
    public class TransacaoHandler(IHttpClientFactory httpClientFactory) : ITransacaoHandler
    {
        private readonly HttpClient _httpClient = httpClientFactory.CreateClient(Configuracao.HttpClientName);

        public async Task<Response<Transacao?>> InserirAsync(InserirTransacaoRequest request)
        {
            var resultado = await _httpClient.PostAsJsonAsync("v1/transacoes", request);
            return await resultado.Content.ReadFromJsonAsync<Response<Transacao?>>()
                ?? new Response<Transacao?>(null, 400, "Não foi possível realizar o cadastro.");
        }

        public async Task<Response<Transacao?>> AlterarAsync(AlterarTransacaoRequest request)
        {
            var resultado = await _httpClient.PutAsJsonAsync($"v1/transacoes/{request.Codigo}", request);
            return await resultado.Content.ReadFromJsonAsync<Response<Transacao?>>()
                ?? new Response<Transacao?>(null, 400, "Não foi possível realizar a alteração.");
        }

        public async Task<Response<Transacao?>> ApagarAsync(ApagarTransacaoRequest request)
        {
            var resultado = await _httpClient.DeleteAsync($"v1/transacoes/{request.Codigo}");
            return await resultado.Content.ReadFromJsonAsync<Response<Transacao?>>()
                ?? new Response<Transacao?>(null, 400, "Não foi possível realizar a remoção.");
        }

        public async Task<Response<Transacao?>> SelecionarPorCodigoAsync(SelecionarTransacaoPorCodigoRequest request)
        {
            return await _httpClient.GetFromJsonAsync<Response<Transacao?>>($"v1/transacoes/{request.Codigo}")
                ?? new Response<Transacao?>(null, 400, "Não foi possível obter o registro.");
        }

        public async Task<PagedResponse<List<Transacao>?>> SelecionarPorDataAsync(SelecionarTransacaoPorDataRequest request)
        {
            const string format = "yyyy-MM-dd";

            var dataInicial = request.DataInicial is not null 
                ? request.DataInicial.Value.ToString(format)
                : DateTime.Now.PrimeiroDia().ToString(format);

            var dataFinal = request.DataFinal is not null
                ? request.DataFinal.Value.ToString(format)
                : DateTime.Now.UltimoDia().ToString(format);

            var url = $"v1/transacoes?dataInicial={dataInicial}&dataFinal={dataFinal}";

            return await _httpClient.GetFromJsonAsync<PagedResponse<List<Transacao>?>>(url)
                ?? new PagedResponse<List<Transacao>?>(null, 400, "Não foi possível obter os registros.");
        }
    }
}
