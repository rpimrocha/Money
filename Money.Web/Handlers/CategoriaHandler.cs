using Money.Core.Handlers;
using Money.Core.Models;
using Money.Core.Requests.Categorias;
using Money.Core.Responses;
using System.Net.Http.Json;

namespace Money.Web.Handlers
{
    public class CategoriaHandler(IHttpClientFactory httpClientFactory) : ICategoriaHandler
    {
        private readonly HttpClient _httpClient = httpClientFactory.CreateClient(Configuracao.HttpClientName);

        public async Task<Response<Categoria?>> InserirAsync(InserirCategoriaRequest request)
        {
            var resultado = await _httpClient.PostAsJsonAsync("v1/categorias", request);
            return await resultado.Content.ReadFromJsonAsync<Response<Categoria?>>() 
                ?? new Response<Categoria?>(null, 400, "Não foi possível realizar o cadastro.");
        }
        
        public async Task<Response<Categoria?>> AlterarAsync(AlterarCategoriaRequest request)
        {
            var resultado = await _httpClient.PutAsJsonAsync($"v1/categorias/{request.Codigo}", request);
            return await resultado.Content.ReadFromJsonAsync<Response<Categoria?>>()
                ?? new Response<Categoria?>(null, 400, "Não foi possível realizar a alteração.");
        }

        public async Task<Response<Categoria?>> ApagarAsync(ApagarCategoriaRequest request)
        {
            var resultado = await _httpClient.DeleteAsync($"v1/categorias/{request.Codigo}");
            return await resultado.Content.ReadFromJsonAsync<Response<Categoria?>>()
                ?? new Response<Categoria?>(null, 400, "Não foi possível realizar a remoção.");
        }

        public async Task<Response<Categoria?>> SelecionarPorCodigoAsync(SelecionarCategoriaPorCodigoRequest request)
        {
            return await _httpClient.GetFromJsonAsync<Response<Categoria?>>($"v1/categorias/{request.Codigo}")
                ?? new Response<Categoria?>(null, 400, "Não foi possível obter o registro.");
        }

        public async Task<PagedResponse<List<Categoria>>> SelecionarTodosAsync(SelecionarTodasCategoriasRequest request)
        {
            return await _httpClient.GetFromJsonAsync<PagedResponse<List<Categoria>>>("v1/categorias")
                ?? new PagedResponse<List<Categoria>>(null, 400, "Não foi possível obter os registros.");
        }
    }
}
