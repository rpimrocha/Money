using Microsoft.AspNetCore.Components;
using Money.Core.Handlers;
using Money.Core.Models;
using Money.Core.Requests.Categorias;
using Money.Core.Requests.Transacoes;
using MudBlazor;

namespace Money.Web.Pages.Transacoes
{
    public partial class AlterarTransacaoPage : ComponentBase
    {
        #region Parâmetros
        [Parameter]
        public string Codigo { get; set; } = string.Empty;
        #endregion


        #region Propriedades
        public bool IsLoading { get; set; } = false;
        public bool IsSaving { get; set; } = false;
        public List<Categoria> Categorias { get; set; } = [];
        public AlterarTransacaoRequest TransacaoRequest { get; set; } = new();
        #endregion


        #region Servicos
        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        [Inject]
        public ITransacaoHandler TransacaoHandler { get; set; } = null!;

        [Inject]
        public ICategoriaHandler CategoriaHandler { get; set; } = null!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;
        #endregion


        #region Sobreposições
        protected override async Task OnInitializedAsync()
        {
            IsLoading = true;

            await SelecionarCategoriasAsync();
            await SelecionarTransacaoPorCodigoAsync();

            if (TransacaoRequest.Codigo == 0)
            {
                NavigationManager.NavigateTo("/transacoes");
            }

            IsLoading = false;
        }
        #endregion

        #region Privados
        private async Task SelecionarCategoriasAsync()
        {
            IsLoading = true;

            try
            {
                var selecionarTodasCategoriasRequest = new SelecionarTodasCategoriasRequest();
                var response = await CategoriaHandler.SelecionarTodosAsync(selecionarTodasCategoriasRequest);

                if (response.IsSuccess)
                {
                    Categorias = response.Dado ?? [];
                }
                else
                {
                    Snackbar.Add(response.Mensagem, Severity.Warning);
                }
            }
            catch (Exception ex)
            {
                Snackbar.Add($"Ocorreu um erro: {ex.Message}", Severity.Error);
            }
            finally
            {
                IsLoading = false;
            }
        }

        private async Task SelecionarTransacaoPorCodigoAsync()
        {
            SelecionarTransacaoPorCodigoRequest selecionarTransacaoPorCodigoRequest = null!;
            try
            {
                selecionarTransacaoPorCodigoRequest = new SelecionarTransacaoPorCodigoRequest { Codigo = long.Parse(Codigo) };
            }
            catch
            {
                Snackbar.Add($"O código enviado não é válido.", Severity.Error);
            }

            if (selecionarTransacaoPorCodigoRequest is null)
            {
                return;
            }

            try
            {
                var response = await TransacaoHandler.SelecionarPorCodigoAsync(selecionarTransacaoPorCodigoRequest);

                if (response.IsSuccess && response.Dado is not null)
                {
                    TransacaoRequest = new()
                    {
                        Codigo = response.Dado.Codigo,
                        Titulo = response.Dado.Titulo,
                        CodigoCategoria = response.Dado.CodigoCategoria,
                        Tipo = response.Dado.Tipo,
                        DataPagamento = response.Dado.DataPagamento,
                        Valor = response.Dado.Valor
                    };
                }
                else
                {
                    Snackbar.Add(response.Mensagem, Severity.Warning);
                }
            }
            catch (Exception ex)
            {
                Snackbar.Add($"Ocorreu um erro: {ex.Message}", Severity.Error);
            }
        }
        #endregion


        #region Métodos
        public async Task AlterarAsync()
        {
            IsSaving = true;
            try
            {
                var response = await TransacaoHandler.AlterarAsync(TransacaoRequest);
                if (response.IsSuccess)
                {
                    Snackbar.Add(response.Mensagem, Severity.Success);
                    NavigationManager.NavigateTo("/transacoes");
                }
                else
                {
                    Snackbar.Add(response.Mensagem, Severity.Warning);
                }
            }
            catch (Exception ex)
            {
                Snackbar.Add($"Ocorreu um erro: {ex.Message}", Severity.Error);
            }
            finally
            {
                IsSaving = false;
            }
        }
        #endregion
    }
}