using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money.Core.Requests.Categorias
{
    public class AlterarCategoriaRequest : Request
    {
        [Required(ErrorMessage = "Código inválido. Seu preenchimento é obrigatório.")]
        public long Codigo { get; set; }
        [Required(ErrorMessage = "Título inválido. Seu preenchimento é obrigatório.")]
        [MaxLength(80, ErrorMessage = "Título inválido. Digitar no máximo 80 caracteres.")]
        public string Titulo { get; set; } = string.Empty;
        [Required(ErrorMessage = "Descrição inválida. Seu preenchimento é obrigatório.")]
        [MaxLength(255, ErrorMessage = "Descrição inválida. Digitar no máximo 255 caracteres.")]
        public string Descricao { get; set; } = string.Empty;
    }
}
