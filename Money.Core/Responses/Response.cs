using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Money.Core.Responses
{
    public class Response<TDado>
    {
        private readonly int _codigoStatus;

        [JsonConstructor]
        public Response()
        {
            _codigoStatus = Configuration.CodigoStatusPadrao;
        }

        public Response(TDado? dado, int codigoStatus = Configuration.CodigoStatusPadrao, string? mensagem = null)
        {
            Dado = dado;
            Mensagem = mensagem ?? string.Empty;
            _codigoStatus = codigoStatus;
        }

        public TDado? Dado { get; set; }
        public string Mensagem { get; set; } = string.Empty;

        [JsonIgnore]
        public bool IsSuccess => _codigoStatus is >= 200 and <= 299;
    }
}
