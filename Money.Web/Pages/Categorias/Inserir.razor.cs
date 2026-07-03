using Microsoft.AspNetCore.Components;
using Money.Core.Handlers;
using Money.Core.Requests.Categorias;
using MudBlazor;

namespace Money.Web.Pages.Categorias
{
    public partial class InserirCategoriaPage : ComponentBase
    {
        #region Propriedades
        public bool IsLoading { get; set; } = false;
        public InserirCategoriaRequest CategoriaRequest { get; set; } = new();
        #endregion


        #region Servicos
        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        [Inject]
        public ICategoriaHandler CategoriaHandler { get; set; } = null!;
        
        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;
        #endregion


        #region Métodos
        public async Task InserirAsync()
        {
            IsLoading = true;
            try
            {
                var response = await CategoriaHandler.InserirAsync(CategoriaRequest);
                if (response.IsSuccess)
                {
                    Snackbar.Add(response.Mensagem, Severity.Success);
                    NavigationManager.NavigateTo("/categorias");
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
    }
}
