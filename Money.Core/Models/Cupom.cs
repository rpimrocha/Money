namespace Money.Core.Models
{
    public class Cupom
    {
        public long Codigo { get; set; }
        public string Numero { get; set; } = string.Empty;
        public string Titulo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public bool EstaAtivo { get; set; }
        public decimal Valor { get; set; }
    }
}
