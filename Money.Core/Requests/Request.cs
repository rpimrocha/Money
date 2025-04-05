using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money.Core.Requests
{
    public abstract class Request
    {
        public string CodigoUsuario { get; set; } = string.Empty;
    }
}
