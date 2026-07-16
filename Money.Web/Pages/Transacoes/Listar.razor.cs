using Microsoft.AspNetCore.Components;
using Money.Core.Handlers;
using Money.Core.Models;
using Money.Core.Requests.Transacoes;
using MudBlazor;

namespace Money.Web.Pages.Transacoes
{
    public partial class ListarTransacoesPage : ComponentBase
    {
        #region Propriedades
        public bool IsLoading { get; set; } = false;
        public List<Transacao> Transacoes { get; set; } = [];
        public string TermoFiltro { get; set; } = string.Empty;
        public int AnoAtual { get; set; } = DateTime.Now.Year;
        public int MesAtual { get; set; } = DateTime.Now.Month;
        public int[] Anos { get; set; } =
        {   
            DateTime.Now.Year,
            DateTime.Now.Year - 1,
            DateTime.Now.Year - 2,
            DateTime.Now.Year - 3
        };
        #endregion


        #region Servicos
        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        [Inject]
        public IDialogService DialogService { get; set; } = null!;

        [Inject]
        public ITransacaoHandler TransacaoHandler { get; set; } = null!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;
        #endregion


        #region Sobreposições
        protected override async Task OnInitializedAsync()
        {
            await SelecionarTransacoes();
        }
        #endregion


        #region Métodos
        private async Task SelecionarTransacoes()
        {
            IsLoading = true;

            try
            {
                var selecionarTransacaoPorDataRequest = new SelecionarTransacaoPorDataRequest
                {
                    DataInicial = new DateTime(AnoAtual, MesAtual, 1),
                    DataFinal = new DateTime(AnoAtual, MesAtual, DateTime.DaysInMonth(AnoAtual, MesAtual)),
                    PaginaNumero = 1,
                    RegistrosPorPagina = 1000
                };
                var response = await TransacaoHandler.SelecionarPorDataAsync(selecionarTransacaoPorDataRequest);

                if (response.IsSuccess)
                {
                    Transacoes = response.Dado ?? [];
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

        public async void AoClicarNoBotaoExcluirApagarAsync(long codigo, string titulo)
        {
            var resultado = await DialogService.ShowMessageBox("Atenção",
                $"Deseja apagar a transação \"{titulo}\" selecionada. Essa operação não tem retorno.",
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
                var transacaoRequest = new ApagarTransacaoRequest { Codigo = codigo };
                await TransacaoHandler.ApagarAsync(transacaoRequest);
                Transacoes.RemoveAll(x => x.Codigo == codigo);
                Snackbar.Add($"A transação \"{titulo}\" foi apagada com sucesso", Severity.Success);
            }
            catch (Exception ex)
            {
                Snackbar.Add($"Ocorreu um erro: {ex.Message}", Severity.Error);
            }
        }

        public Func<Transacao, bool> Filtrar => transacao =>
        {
            if (string.IsNullOrWhiteSpace(TermoFiltro))
                return true;

            if (transacao.Codigo.ToString().Contains(TermoFiltro, StringComparison.OrdinalIgnoreCase))
                return true;

            if (transacao.Titulo.Contains(TermoFiltro, StringComparison.OrdinalIgnoreCase))
                return true;

            return false;
        };
        #endregion
    }
}
