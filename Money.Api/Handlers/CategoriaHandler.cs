using Microsoft.EntityFrameworkCore;
using Money.Api.Data;
using Money.Core.Handlers;
using Money.Core.Models;
using Money.Core.Requests.Categorias;
using Money.Core.Responses;

namespace Money.Api.Handlers
{
    public class CategoriaHandler(AppDbContext context) : ICategoriaHandler
    {
        public async Task<Response<Categoria?>> InserirAsync(InserirCategoriaRequest request)
        {
            try
            {
                var categoria = new Categoria
                {
                    Titulo = request.Titulo,
                    Descricao = request.Descricao,
                    CodigoUsuario = request.CodigoUsuario
                };

                await context.Categorias.AddAsync(categoria);
                await context.SaveChangesAsync();

                return new Response<Categoria?>(categoria, 201, "Categoria inserida com sucesso.");
            }
            catch (Exception ex)
            {
                return new Response<Categoria?>(null, 500, $"Erro ao inserir categoria: {ex.Message}");
            }
        }

        public async Task<Response<Categoria?>> AlterarAsync(AlterarCategoriaRequest request)
        {
            try
            {
                var categoria = await context.Categorias.FirstOrDefaultAsync(x => 
                    x.Codigo == request.Codigo && 
                    x.CodigoUsuario == request.CodigoUsuario
                );

                if (categoria is null)
                    return new Response<Categoria?>(null, 404, $"Categoria não encontrada. Código: {request.Codigo}"); 

                categoria.Titulo = request.Titulo;
                categoria.Descricao = request.Descricao;

                context.Categorias.Update(categoria);
                await context.SaveChangesAsync();

                return new Response<Categoria?>(categoria, mensagem: "Categoria alterada com sucesso.");
            }
            catch (Exception ex)
            {
                return new Response<Categoria?>(null, 500, $"Erro ao alterar categoria: {ex.Message}");
            }
        }

        public async Task<Response<Categoria?>> ApagarAsync(ApagarCategoriaRequest request)
        {
            try
            {
                var categoria = await context.Categorias.FirstOrDefaultAsync(x => 
                    x.Codigo == request.Codigo && 
                    x.CodigoUsuario == request.CodigoUsuario
                );

                if (categoria is null)
                    return new Response<Categoria?>(null, 404, $"Categoria não encontrada. Código: {request.Codigo}");

                context.Categorias.Remove(categoria);
                await context.SaveChangesAsync();

                return new Response<Categoria?>(categoria, mensagem: "Categoria apagada com sucesso.");
            }
            catch (Exception ex)
            {
                return new Response<Categoria?>(null, 500, $"Erro ao apagar categoria: {ex.Message}");
            }
        }

        public async Task<Response<Categoria?>> SelecionarPorCodigoAsync(SelecionarCategoriaPorCodigoRequest request)
        {
            try
            {
                var categoria = await context.Categorias.AsNoTracking().FirstOrDefaultAsync(x =>
                    x.Codigo == request.Codigo &&
                    x.CodigoUsuario == request.CodigoUsuario
                );

                return categoria is null
                    ? new Response<Categoria?>(null, 404, $"Categoria não encontrada. Código: {request.Codigo}")
                    : new Response<Categoria?>(categoria, mensagem: "Categoria encontrada com sucesso.");
            }
            catch (Exception ex)
            {
                return new Response<Categoria?>(null, 500, $"Erro ao pesquisar a categoria {request.Codigo}: {ex.Message}");
            }
        }

        public async Task<PagedResponse<List<Categoria>>> SelecionarTodosAsync(SelecionarTodasCategoriasRequest request)
        {
            try
            {
                var query = context.Categorias.AsNoTracking()
                    .Where(x => x.CodigoUsuario == request.CodigoUsuario)
                    .OrderBy(x => x.Titulo);

                var categorias = await query
                    .Skip(request.RegistrosPorPagina * (request.PaginaNumero - 1))
                    .Take(request.RegistrosPorPagina)
                    .ToListAsync();

                var totalItens = await query.CountAsync();

                return new PagedResponse<List<Categoria>>(categorias, totalItens, request.PaginaNumero, request.RegistrosPorPagina);
            }
            catch (Exception ex)
            {
                return new PagedResponse<List<Categoria>>(null, 500, $"Erro ao pesquisar todas as categorias: {ex.Message}");
            }
        }
    }
}
