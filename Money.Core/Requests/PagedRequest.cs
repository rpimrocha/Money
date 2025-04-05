using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money.Core.Requests
{
    public abstract class PagedRequest : Request
    {
        public int PaginaNumero { get; set; } = Configuracao.PaginaNumeroPadrao;
        public int RegistrosPorPagina { get; set; } = Configuracao.TamanhoPaginaPadrao;
    }
}
