using Microsoft.AspNetCore.Components;
using Money.Core.Handlers;
using Money.Core.Models.Relatorios;
using Money.Core.Requests.Relatorios;
using MudBlazor;

namespace Money.Web.Pages
{
    public partial class HomePage : ComponentBase
    {
        #region Propriedades
        public bool IsLoading { get; set; } = false;
        public bool ExibirValores { get; set; } = true;
        public ResultadoFinanceiro? Resultado { get; set; }
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
                var selecionarResultadoFinanceiroRequest = new SelecionarResultadoFinanceiroRequest();
                var response = await RelatorioHandler.SelecionarResultadoFinanceiroAsync(selecionarResultadoFinanceiroRequest);

                if (!response.IsSuccess || response.Dado is null)
                {
                    Snackbar.Add(response.Mensagem, Severity.Warning);
                    return;
                }

                Resultado = response.Dado;
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
        public void AlternarExibirValores()
        {
            ExibirValores = !ExibirValores;
        }

        #endregion
    }
}
