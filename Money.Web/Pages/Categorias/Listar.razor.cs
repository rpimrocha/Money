using Microsoft.AspNetCore.Components;
using Money.Core.Handlers;
using Money.Core.Models;
using Money.Core.Requests.Categorias;
using MudBlazor;

namespace Money.Web.Pages.Categorias
{
    public partial class ListarCategoriasPage : ComponentBase
    {
        #region Propriedades
        public bool IsLoading { get; set; } = false;
        public List<Categoria> Categorias { get; set; } = [];
        public string TermoFiltro { get; set; } = string.Empty;
        #endregion


        #region Servicos
        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        [Inject]
        public IDialogService DialogService { get; set; } = null!;

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
        public async void AoClicarNoBotaoExcluirApagarAsync(long codigo, string titulo)
        {
            var resultado = await DialogService.ShowMessageBox("Atenção", 
                $"Deseja apagar a categoria \"{titulo}\" selecionada. Essa operação não tem retorno.",
                yesText: "Apagar", cancelText: "Cancelar");

            if (resultado is true)
            {
                await ApagarAsync(codigo, titulo);
            }

            StateHasChanged();
        }

        public async Task ApagarAsync(long codigo, string titulo)
        {
            try
            {
                var categoriaRequest = new ApagarCategoriaRequest { Codigo = codigo };
                await CategoriaHandler.ApagarAsync(categoriaRequest);
                Categorias.RemoveAll(x => x.Codigo == codigo);
                Snackbar.Add($"A categoria \"{titulo}\" foi apagada com sucesso", Severity.Success);
            }
            catch (Exception ex)
            {
                Snackbar.Add($"Ocorreu um erro: {ex.Message}", Severity.Error);
            }
        }

        public Func<Categoria, bool> Filtrar => categoria =>
        {
            if (string.IsNullOrWhiteSpace(TermoFiltro))
                return true;

            if (categoria.Codigo.ToString().Contains(TermoFiltro, StringComparison.OrdinalIgnoreCase))
                return true;

            if (categoria.Titulo.Contains(TermoFiltro, StringComparison.OrdinalIgnoreCase))
                return true;

            if (categoria.Descricao is not null && categoria.Descricao.Contains(TermoFiltro, StringComparison.OrdinalIgnoreCase))
                return true;

            return false;
        };
        #endregion
    }
}
