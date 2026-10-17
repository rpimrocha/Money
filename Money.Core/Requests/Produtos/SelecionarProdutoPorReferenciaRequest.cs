namespace Money.Core.Requests.Produtos
{
    public class SelecionarProdutoPorReferenciaRequest : Request
    {
        public string Referencia { get; set; } = string.Empty;
    }
}
