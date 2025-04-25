using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money.Core.Requests.Transacoes
{
    public class SelecionarTransacaoPorDataRequest : PagedRequest
    {
        public DateTime? DataInicial { get; set; }
        public DateTime? DataFinal { get; set; }
    }
}
