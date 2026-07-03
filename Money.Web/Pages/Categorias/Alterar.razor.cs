using Microsoft.AspNetCore.Components;
using Money.Core.Handlers;
using Money.Core.Requests.Categorias;
using MudBlazor;

namespace Money.Web.Pages.Categorias
{
    public partial class AlterarCategoriaPage : ComponentBase
    {
        #region Parâmetros
        [Parameter]
        public string Codigo { get; set; } = string.Empty;
        #endregion


        #region Propriedades
        public bool IsLoading { get; set; } = false;
        public bool IsSaving { get; set; } = false;
        public AlterarCategoriaRequest CategoriaRequest { get; set; } = new();
        #endregion


        #region Servicos
        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        [Inject]
        public ICategoriaHandler CategoriaHandler { get; set; } = null!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;
        #endregion


        #region Sobreposições
        protected override async Task OnInitializedAsync()
        {
            SelecionarCategoriaPorCodigoRequest selecionarCategoriaPorCodigoRequest = null!;
            try
            {
                selecionarCategoriaPorCodigoRequest = new SelecionarCategoriaPorCodigoRequest { Codigo = long.Parse(Codigo) };
            }
            catch
            {
                Snackbar.Add($"O código enviado não é válido.", Severity.Error);
            }

            if (selecionarCategoriaPorCodigoRequest is null)
            {
                NavigationManager.NavigateTo("/categorias");
                return;
            }

            IsLoading = true;

            try
            {
                var response = await CategoriaHandler.SelecionarPorCodigoAsync(selecionarCategoriaPorCodigoRequest);

                if (response.IsSuccess && response.Dado is not null)
                {
                    CategoriaRequest = new()
                    {
                        Codigo = response.Dado.Codigo,
                        Titulo = response.Dado.Titulo,
                        Descricao = response.Dado.Descricao
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
            finally
            {
                IsLoading = false;
            }
        }
        #endregion


        #region Métodos
        public async Task AlterarAsync()
        {
            IsSaving = true;
            try
            {
                var response = await CategoriaHandler.AlterarAsync(CategoriaRequest);
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
                IsSaving = false;
            }
        }
        #endregion
    }
}
