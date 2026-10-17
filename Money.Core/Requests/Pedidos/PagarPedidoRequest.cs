namespace Money.Core.Requests.Pedidos
{
    public class PagarPedidoRequest : Request
    {
        public long Codigo { get; set; }
        public string ReferenciaPortalPagamento { get; set; } = string.Empty;
    }
}
