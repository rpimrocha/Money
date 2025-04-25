using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money.Core.Requests.Transacoes
{
    public class SelecionarTransacaoPorCodigoRequest : Request
    {
        public long Codigo { get; set; }
    }
}
