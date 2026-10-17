namespace Money.Core.Requests.Cupons
{
    public class SelecionarCupomPorNumeroRequest : Request
    {
        public string Numero { get; set; } = string.Empty;
    }
}
