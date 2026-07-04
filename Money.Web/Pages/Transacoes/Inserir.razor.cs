using Microsoft.AspNetCore.Components;
using Money.Core.Handlers;
using Money.Core.Models;
using Money.Core.Requests.Categorias;
using Money.Core.Requests.Transacoes;
using MudBlazor;

namespace Money.Web.Pages.Transacoes
{
    public partial class InserirTransacaoPage : ComponentBase
    {
        #region Propriedades
        public bool IsLoading { get; set; } = false;
        public bool IsSaving { get; set; } = false;
        public List<Categoria> Categorias { get; set; } = [];
        public InserirTransacaoRequest TransacaoRequest { get; set; } = new();
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

            try
            {
                var selecionarTodasCategoriasRequest = new SelecionarTodasCategoriasRequest();
                var response = await CategoriaHandler.SelecionarTodosAsync(selecionarTodasCategoriasRequest);

                if (response.IsSuccess)
                {
                    Categorias = response.Dado ?? [];
                    TransacaoRequest.CodigoCategoria = Categorias.FirstOrDefault()?.Codigo ?? 0;
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
        #endregion


        #region Métodos
        public async Task InserirAsync()
        {
            IsSaving = true;
            try
            {
                var response = await TransacaoHandler.InserirAsync(TransacaoRequest);
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
