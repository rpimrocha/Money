using Microsoft.EntityFrameworkCore;
using Money.Core.Models;

namespace Money.Api.Data.Mappings
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produtos");

            builder.HasKey(p => p.Codigo);
            builder.Property(p => p.Codigo)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Referencia)
                .IsRequired()
                .HasColumnType("VARCHAR")
                .HasMaxLength(80);

            builder.Property(p => p.Titulo)
                .IsRequired()
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

            builder.Property(p => p.Descricao)
                .IsRequired(false)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(255);

            builder.Property(p => p.Valor)
                .IsRequired()
                .HasColumnType("MONEY");

            builder.Property(p => p.EstaAtivo)
                .IsRequired()
                .HasColumnType("BIT");
        }
    }
}
