namespace Money.Core.Requests.Pedidos
{
    public class SelecionarPedidoPorNumeroRequest : Request
    {
        public string Numero { get; set; } = string.Empty;
    }
}
