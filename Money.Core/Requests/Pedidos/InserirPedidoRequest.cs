namespace Money.Core.Requests.Pedidos
{
    public class InserirPedidoRequest : Request
    {
        public long CodigoProduto { get; set; }
        public long CodigoCupom { get; set; }
    }
}
