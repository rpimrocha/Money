using Microsoft.EntityFrameworkCore;
using Money.Core.Models;

namespace Money.Api.Data.Mappings
{
    public class PedidoMapping : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedidos");

            builder.HasKey(p => p.Codigo);
            builder.Property(p => p.Codigo)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Numero)
                .IsRequired()
                .HasColumnType("CHAR")
                .HasMaxLength(8);

            builder.Property(p => p.DataCadastro)
                .IsRequired()
                .HasColumnType("DATETIME");

            builder.Property(p => p.DataAtualizacao)
                .IsRequired()
                .HasColumnType("DATETIME");

            builder.Property(p => p.ReferenciaPortalPagamento)
                .IsRequired(false)
                .HasColumnType("VARCHAR")
                .HasMaxLength(60);

            builder.Property(p => p.PortalPagamento)
                .IsRequired()
                .HasColumnType("SMALLINT");

            builder.Property(p => p.SituacaoPedido)
                .IsRequired()
                .HasColumnType("SMALLINT");

            builder.Property(p => p.CodigoProduto)
                .IsRequired()
                .HasColumnType("BIGINT");

            builder.Property(p => p.CodigoCupom)
                .IsRequired(false)
                .HasColumnType("BIGINT");
            
            builder.Property(t => t.CodigoUsuario)
               .IsRequired()
               .HasColumnType("VARCHAR")
               .HasMaxLength(160);

            builder.HasOne(p => p.Produto).WithMany()
                .HasForeignKey(p => p.CodigoProduto)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Cupom).WithMany()
                .HasForeignKey(p => p.CodigoCupom)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}