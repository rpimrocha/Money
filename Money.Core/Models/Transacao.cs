using Money.Core.Enums;

namespace Money.Core.Models
{
    public class Transacao
    {
        public int Codigo { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public DateTime DataCadastro { get; set; } = DateTime.Now;
        public DateTime? DataPagamento { get; set; }
        public ETipoTransacao Tipo { get; set; } = ETipoTransacao.Saida;
        public decimal Valor { get; set; }
        public long CodigoCategoria { get; set; }
        public Categoria Categoria { get; set; } = null!;
        public string CodigoUsuario { get; set; } = string.Empty;
    }
}
