using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money.Core.Requests
{
    public abstract class PaginaRequest : BaseRequest
    {
        public int PaginaNumero { get; set; } = Configuration.PaginaNumeroPadrao;
        public int TamanhoPagina { get; set; } = Configuration.TamanhoPaginaPadrao;
    }
}
