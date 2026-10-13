using Microsoft.AspNetCore.Components;
using Money.Core.Handlers;
using Money.Core.Requests.Relatorios;
using MudBlazor;

namespace Money.Web.Components.Relatorios
{
    public partial class GraficoReceitasPorCategoriaPage : ComponentBase
    {
        #region Propriedades
        public bool IsLoading { get; set; } = false;
        public List<double> Dados { get; set; } = [];
        public List<string> Rotulos { get; set; } = [];
        #endregion


        #region Serviços
        [Inject]
        public IRelatorioHandler RelatorioHandler { get; set; } = null!;

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;
        #endregion


        #region Sobreposições
        protected override async Task OnInitializedAsync()
        {
            IsLoading = true;

            try
            {
                var selecionarReceitasPorCategoriaRequest = new SelecionarReceitasPorCategoriaRequest();
                var response = await RelatorioHandler.SelecionarReceitasPorCategoriaAsync(selecionarReceitasPorCategoriaRequest);

                if (!response.IsSuccess || response.Dado is null)
                {
                    Snackbar.Add(response.Mensagem, Severity.Warning);
                    return;
                }

                foreach (var item in response.Dado)
                {
                    Rotulos.Add($"{item.Categoria} ({item.Valor:C})");
                    Dados.Add((double)item.Valor);
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
