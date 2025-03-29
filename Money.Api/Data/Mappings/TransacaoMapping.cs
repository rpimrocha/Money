using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Money.Core.Models;

namespace Money.Api.Data.Mappings
{
    public class TransacaoMapping : IEntityTypeConfiguration<Transacao>
    {
        public void Configure(EntityTypeBuilder<Transacao> builder)
        {
            builder.ToTable("Transacoes");

            builder.HasKey(t => t.Codigo);
            builder.Property(t => t.Codigo)
                .ValueGeneratedOnAdd();

            builder.Property(t => t.Titulo)
                .IsRequired()
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

            builder.Property(t => t.DataCadastro)
                .IsRequired()
                .HasColumnType("DATETIME");

            builder.Property(t => t.DataPagamento)
                .IsRequired(false)
                .HasColumnType("DATETIME");

            builder.Property(t => t.Tipo)
                .IsRequired()
                .HasColumnType("SMALLINT");

            builder.Property(t => t.Valor)
                .IsRequired()
                .HasColumnType("MONEY");

            builder.Property(t => t.CodigoCategoria)
                .IsRequired()
                .HasColumnType("BIGINT");

            builder.Property(t => t.CodigoUsuario)
                .IsRequired()
                .HasColumnType("VARCHAR")
                .HasMaxLength(160);

            builder.HasOne(t => t.Categoria)
                .WithMany()
                .HasForeignKey(t => t.CodigoCategoria);

            builder.HasIndex(t => t.CodigoUsuario);
                
        }
    }
}
