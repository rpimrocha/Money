using Money.Core.Enums;

namespace Money.Core.Models
{
    public class Pedido
    {
        public long Codigo { get; set; }
        public string Numero { get; set; } = Guid.NewGuid().ToString("N")[..8];
        public DateTime DataCadastro { get; set; } = DateTime.Now;
        public DateTime DataAtualizacao { get; set; } = DateTime.Now;
        public string? ReferenciaPortalPagamento { get; set; }
        public EPortalPagamento PortalPagamento { get; set; } = EPortalPagamento.Stripe;
        public ESituacaoPedido SituacaoPedido { get; set; } = ESituacaoPedido.AguardandoPagamento;
        public long CodigoProduto { get; set; }
        public Produto Produto { get; set; } = null!;
        public long? CodigoCupom { get; set; }
        public Cupom? Cupom { get; set; }
        public string CodigoUsuario { get; set; } = string.Empty;
        public decimal Total => Produto.Valor - (Cupom?.Valor ?? 0);
    }
}
