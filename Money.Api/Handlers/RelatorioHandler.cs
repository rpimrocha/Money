using Microsoft.EntityFrameworkCore;
using Money.Api.Data;
using Money.Core.Enums;
using Money.Core.Handlers;
using Money.Core.Models.Relatorios;
using Money.Core.Requests.Relatorios;
using Money.Core.Responses;

namespace Money.Api.Handlers
{
    public class RelatorioHandler(AppDbContext context) : IRelatorioHandler
    {
        public async Task<Response<List<DespesasPorCategoria>?>> SelecionarDespesasPorCategoriaAsync(SelecionarDespesasPorCategoriaRequest request)
        {
            try
            {
                var despesasPorCategoria = await context.DespesasPorCategoria.AsNoTracking()
                    .Where(x => x.CodigoUsuario == request.CodigoUsuario)
                    .OrderByDescending(x => x.Ano)
                    .ThenBy(x => x.Categoria)
                    .ToListAsync();

                return new Response<List<DespesasPorCategoria>?>(despesasPorCategoria);
            }
            catch (Exception ex)
            {
                return new Response<List<DespesasPorCategoria>?>(null, 500, $"Erro ao pesquisar todas as despesas por categoria: {ex.Message}");
            }
        }

        public async Task<Response<List<ReceitasPorCategoria>?>> SelecionarReceitasPorCategoriaAsync(SelecionarReceitasPorCategoriaRequest request)
        {
            try
            {
                var receitasPorCategoria = await context.ReceitasPorCategoria.AsNoTracking()
                    .Where(x => x.CodigoUsuario == request.CodigoUsuario)
                    .OrderByDescending(x => x.Ano)
                    .ThenBy(x => x.Categoria)
                    .ToListAsync();

                return new Response<List<ReceitasPorCategoria>?>(receitasPorCategoria);
            }
            catch (Exception ex)
            {
                return new Response<List<ReceitasPorCategoria>?>(null, 500, $"Erro ao pesquisar todas as receitas por categoria: {ex.Message}");
            }
        }

        public async Task<Response<List<ReceitasVersusDespesas>?>> SelecionarReceitasVersusDespesasAsync(SelecionarReceitasVersusDespesasRequest request)
        {
            try
            {
                var receitasVersusDespesas = await context.ReceitasVersusDespesas.AsNoTracking()
                    .Where(x => x.CodigoUsuario == request.CodigoUsuario)
                    .OrderByDescending(x => x.Ano)
                    .ThenBy(x => x.Mes)
                    .ToListAsync();

                return new Response<List<ReceitasVersusDespesas>?>(receitasVersusDespesas);
            }
            catch (Exception ex)
            {
                return new Response<List<ReceitasVersusDespesas>?>(null, 500, $"Erro ao pesquisar todas as receitas versus as despesas: {ex.Message}");
            }
        }

        public async Task<Response<ResultadoFinanceiro?>> SelecionarResultadoFinanceiroAsync(SelecionarResultadoFinanceiroRequest request)
        {
            try
            {
                var dataInicial = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

                var resultadoFinanceiro = await context.Transacoes.AsNoTracking()
                    .Where(x => x.CodigoUsuario == request.CodigoUsuario &&
                                x.DataPagamento >= dataInicial &&
                                x.DataPagamento <= DateTime.Now
                    )
                    .GroupBy(x => 1)
                    .Select(x => new ResultadoFinanceiro(
                        request.CodigoUsuario,
                        x.Where(t => t.Tipo == ETipoTransacao.Entrada).Sum(t => t.Valor),
                        x.Where(t => t.Tipo == ETipoTransacao.Saida).Sum(t => t.Valor))
                    )
                    .FirstOrDefaultAsync();

                return new Response<ResultadoFinanceiro?>(resultadoFinanceiro);
            }
            catch (Exception ex)
            {
                return new Response<ResultadoFinanceiro?>(null, 500, $"Erro ao pesquisar o resultado financeiro: {ex.Message}");
            }
        }
    }
}
