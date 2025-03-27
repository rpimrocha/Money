using Money.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money.Core.Models
{
    public class Transacao
    {
        public int Codigo { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public DateTime DataCadastro { get; set; } = DateTime.Now;
        public DateTime? DataTransacao { get; set; }
        public ETipoTransacao Tipo { get; set; } = ETipoTransacao.Saida;
        public decimal Valor { get; set; }
        public long CodigoCategoria { get; set; }
        public Categoria Categoria { get; set; } = null!;
        public string CodigoUsuario { get; set; } = string.Empty;
    }
}
