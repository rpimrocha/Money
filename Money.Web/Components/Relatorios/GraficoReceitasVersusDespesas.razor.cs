using Microsoft.AspNetCore.Components;
using Money.Core.Handlers;
using Money.Core.Requests.Relatorios;
using MudBlazor;
using System.Globalization;

namespace Money.Web.Components.Relatorios
{
    public partial class GraficoReceitasVersusDespesasPage : ComponentBase
    {
        #region Propriedades
        public bool IsLoading { get; set; } = false;
        public ChartOptions ChartOptions { get; set; } = new ChartOptions();
        public List<ChartSeries>? ChartSeries { get; set; }
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
                var selecionarReceitasVersusDespesasRequest = new SelecionarReceitasVersusDespesasRequest();
                var response = await RelatorioHandler.SelecionarReceitasVersusDespesasAsync(selecionarReceitasVersusDespesasRequest);

                if (!response.IsSuccess || response.Dado is null)
                {
                    Snackbar.Add(response.Mensagem, Severity.Warning);
                    return;
                }

                var receitas = new List<double>();
                var despesas = new List<double>();  

                foreach (var item in response.Dado)
                {
                    receitas.Add((double)item.Receitas);
                    despesas.Add(-(double)item.Despesas);
                    Rotulos.Add(ObterMes(item.Mes));
                }

                ChartOptions.YAxisTicks = 1000;
                ChartOptions.LineStrokeWidth = 5;
                ChartOptions.ChartPalette = [ "#76FF01", Colors.Red.Default ];

                ChartSeries = [ new ChartSeries { Name = "Receitas", Data = receitas.ToArray() },
                    new ChartSeries { Name = "Despesas", Data = despesas.ToArray() }
                ];

                StateHasChanged();
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

        private static string ObterMes(int mes)
        {
            if (mes < 1 || mes > 12)
            {
                throw new ArgumentOutOfRangeException(nameof(mes), $"Mês inválido: {mes}");
            }

            return new DateTime(DateTime.Now.Year, mes, 1).ToString("MMMM", CultureInfo.CurrentCulture);
        }
        #endregion
    }
}