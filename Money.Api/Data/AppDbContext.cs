using Microsoft.EntityFrameworkCore;
using Money.Core.Models;
using System.Reflection;

namespace Money.Api.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Categoria> Categorias { get; set; } = null!;
        public DbSet<Transacao> Transacoes { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*
            Rodar o comando abaixo no terminal para ativar migrações:
            >dotnet tool install--global dotnet-ef
            
            Rodar o comando abaixo no terminal para criar o script da migração:
            >dotnet ef migrations add v1
            
            Rodar para remover o scriptda migração criada:
            >dotnet ef migrations remove v1
            
            Rodar para atualizar o banco de dados:
            >dotnet ef database update
            */

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
