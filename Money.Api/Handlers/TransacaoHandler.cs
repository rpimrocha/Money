using Microsoft.EntityFrameworkCore;
using Money.Api.Data;
using Money.Core.Common.Extensions;
using Money.Core.Enums;
using Money.Core.Handlers;
using Money.Core.Models;
using Money.Core.Requests.Transacoes;
using Money.Core.Responses;

namespace Money.Api.Handlers
{
    public class TransacaoHandler(AppDbContext context) : ITransacaoHandler
    {
        public async Task<Response<Transacao?>> InserirAsync(InserirTransacaoRequest request)
        {
            try
            {
                if (request is { Tipo: ETipoTransacao.Saida, Valor: > 0 })
                {
                    request.Valor *= -1;
                }

                var transacao = new Transacao
                {
                    Titulo = request.Titulo,
                    DataCadastro = DateTime.Now,
                    DataPagamento = request.DataPagamento,
                    Tipo = request.Tipo,
                    Valor = request.Valor,
                    CodigoCategoria = request.CodigoCategoria,
                    CodigoUsuario = request.CodigoUsuario
                };

                await context.Transacoes.AddAsync(transacao);
                await context.SaveChangesAsync();

                return new Response<Transacao?>(transacao, 201, "Transação inserida com sucesso.");
            }
            catch (Exception ex)
            {
                return new Response<Transacao?>(null, 500, $"Erro ao inserir transação: {ex.Message}");
            }
        }

        public async Task<Response<Transacao?>> AlterarAsync(AlterarTransacaoRequest request)
        {
            try
            {
                var Transacao = await context.Transacoes.FirstOrDefaultAsync(x =>
                    x.Codigo == request.Codigo &&
                    x.CodigoUsuario == request.CodigoUsuario
                );

                if (Transacao is null)
                    return new Response<Transacao?>(null, 404, $"Transação não encontrada. Código: {request.Codigo}");

                if (request is { Tipo: ETipoTransacao.Saida, Valor: > 0 })
                {
                    request.Valor *= -1;
                }

                Transacao.Titulo = request.Titulo;
                Transacao.DataPagamento = request.DataPagamento;
                Transacao.Tipo = request.Tipo;
                Transacao.Valor = request.Valor;
                Transacao.CodigoCategoria = request.CodigoCategoria;

                context.Transacoes.Update(Transacao);
                await context.SaveChangesAsync();

                return new Response<Transacao?>(Transacao, mensagem: "Transação alterada com sucesso.");
            }
            catch (Exception ex)
            {
                return new Response<Transacao?>(null, 500, $"Erro ao alterar Transação: {ex.Message}");
            }
        }

        public async Task<Response<Transacao?>> ApagarAsync(ApagarTransacaoRequest request)
        {
            try
            {
                var Transacao = await context.Transacoes.FirstOrDefaultAsync(x =>
                    x.Codigo == request.Codigo &&
                    x.CodigoUsuario == request.CodigoUsuario
                );

                if (Transacao is null)
                    return new Response<Transacao?>(null, 404, $"Transação não encontrada. Código: {request.Codigo}");

                context.Transacoes.Remove(Transacao);
                await context.SaveChangesAsync();

                return new Response<Transacao?>(Transacao, mensagem: "Transação apagada com sucesso.");
            }
            catch (Exception ex)
            {
                return new Response<Transacao?>(null, 500, $"Erro ao apagar Transação: {ex.Message}");
            }
        }

        public async Task<Response<Transacao?>> SelecionarPorCodigoAsync(SelecionarTransacaoPorCodigoRequest request)
        {
            try
            {
                var Transacao = await context.Transacoes.AsNoTracking().FirstOrDefaultAsync(x =>
                    x.Codigo == request.Codigo &&
                    x.CodigoUsuario == request.CodigoUsuario
                );

                return Transacao is null
                    ? new Response<Transacao?>(null, 404, $"Transação não encontrada. Código: {request.Codigo}")
                    : new Response<Transacao?>(Transacao, mensagem: "Transação encontrada com sucesso.");
            }
            catch (Exception ex)
            {
                return new Response<Transacao?>(null, 500, $"Erro ao pesquisar a Transação {request.Codigo}: {ex.Message}");
            }
        }

        public async Task<PagedResponse<List<Transacao>?>> SelecionarPorDataAsync(SelecionarTransacaoPorDataRequest request)
        {
            try
            {
                request.DataInicial ??= DateTime.Now.PrimeiroDia();
                request.DataFinal ??= DateTime.Now.UltimoDia();
            }
            catch (Exception ex)
            {
                return new PagedResponse<List<Transacao>?>(null, 500, $"Erro ao determinar o intervalo de datas de início e término: {ex.Message}");
            }

            try
            {
                var query = context.Transacoes.AsNoTracking()
                    .Where(x => x.CodigoUsuario == request.CodigoUsuario &&
                                x.DataPagamento >= request.DataInicial &&
                                x.DataPagamento <= request.DataFinal)
                    .OrderBy(x => x.DataPagamento);

                var transacoes = await query
                    .Skip(request.RegistrosPorPagina * (request.PaginaNumero - 1))
                    .Take(request.RegistrosPorPagina)
                    .ToListAsync();

                var totalItens = await query.CountAsync();

                return new PagedResponse<List<Transacao>?>(transacoes, totalItens, request.PaginaNumero, request.RegistrosPorPagina);
            }
            catch (Exception ex)
            {
                return new PagedResponse<List<Transacao>?>(null, 500, $"Erro ao pesquisar todas as Transações: {ex.Message}");
            }
        }
    }
}
