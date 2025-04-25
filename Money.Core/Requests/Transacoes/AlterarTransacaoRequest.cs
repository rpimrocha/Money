using Money.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money.Core.Requests.Transacoes
{
    public class AlterarTransacaoRequest : Request
    {
        [Required(ErrorMessage = "Código inválido. Seu preenchimento é obrigatório.")]
        public long Codigo { get; set; }
        [Required(ErrorMessage = "Título inválido. Seu preenchimento é obrigatório.")]
        public string Titulo { get; set; } = string.Empty;
        [Required(ErrorMessage = "Data de pagamento inválida. Seu preenchimento é obrigatório.")]
        public DateTime? DataPagamento { get; set; }
        [Required(ErrorMessage = "Tipo inválido. Seu preenchimento é obrigatório.")]
        public ETipoTransacao Tipo { get; set; } = ETipoTransacao.Saida;
        [Required(ErrorMessage = "Valor inválido. Seu preenchimento é obrigatório.")]
        public decimal Valor { get; set; }
        [Required(ErrorMessage = "Código da categoria inválido. Seu preenchimento é obrigatório.")]
        public long CodigoCategoria { get; set; }
    }
}
