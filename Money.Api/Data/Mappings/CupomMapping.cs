using Microsoft.EntityFrameworkCore;
using Money.Core.Models;

namespace Money.Api.Data.Mappings
{
    public class CupomMapping : IEntityTypeConfiguration<Cupom>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Cupom> builder)
        {
            builder.ToTable("Cupons");

            builder.HasKey(c => c.Codigo);
            builder.Property(c => c.Codigo)
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Numero)
                .IsRequired()
                .HasColumnType("CHAR")
                .HasMaxLength(8);

            builder.Property(c => c.Titulo)
                .IsRequired()
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

            builder.Property(c => c.Descricao)
                .IsRequired(false)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(255);

            builder.Property(c => c.EstaAtivo)
                .IsRequired()
                .HasColumnType("BIT");

            builder.Property(c => c.Valor)
                .IsRequired()
                .HasColumnType("MONEY");
        }
    }
}