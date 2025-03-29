using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money.Core.Models
{
    public class Categoria
    {
        public long Codigo { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string? Descricao { get; set; }
        public string CodigoUsuario { get; set; } = string.Empty;
    }
}
