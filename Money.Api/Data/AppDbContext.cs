using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Money.Api.Models;
using Money.Core.Models;
using Money.Core.Models.Relatorios;
using System.Reflection;

namespace Money.Api.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<User, 
            IdentityRole<long>, long,
            IdentityUserClaim<long>, 
            IdentityUserRole<long>, 
            IdentityUserLogin<long>, 
            IdentityRoleClaim<long>, 
            IdentityUserToken<long>
        >(options)
    {
        public DbSet<Categoria> Categorias { get; set; } = null!;
        public DbSet<Transacao> Transacoes { get; set; } = null!;
        public DbSet<Produto> Produtos { get; set; } = null!;
        public DbSet<Pedido> Pedidos { get; set; } = null!;
        public DbSet<Cupom> Cupons { get; set; } = null!;


        public DbSet<DespesasPorCategoria> DespesasPorCategoria { get; set; } = null!;
        public DbSet<ReceitasPorCategoria> ReceitasPorCategoria { get; set; } = null!;
        public DbSet<ReceitasVersusDespesas> ReceitasVersusDespesas { get; set; } = null!;

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

            modelBuilder.Entity<DespesasPorCategoria>().HasNoKey().ToView("ViewObterDespesasPorCategoria");
            modelBuilder.Entity<ReceitasPorCategoria>().HasNoKey().ToView("ViewObterReceitasPorCategoria");
            modelBuilder.Entity<ReceitasVersusDespesas>().HasNoKey().ToView("ViewObterReceitasVersusDespesas");
        }
    }
}
