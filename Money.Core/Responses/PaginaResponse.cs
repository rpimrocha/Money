using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks; 

namespace Money.Core.Responses
{
    public abstract class PaginaResponse<TDado> : Response<TDado>
    {
        [JsonConstructor]
        public PaginaResponse(TDado? dado, int totalItens, int paginaAtual = Configuration.PaginaNumeroPadrao, 
            int tamanhoPagina = Configuration.TamanhoPaginaPadrao) : base(dado)
        {
            Dado = dado;
            TotalItens = totalItens;
            PaginaAtual = paginaAtual;
            TamanhoPagina = tamanhoPagina;
        }

        public PaginaResponse(TDado? dado, int codigoStatus = Configuration.CodigoStatusPadrao, 
            string? mensagem = null) : base(dado, codigoStatus, mensagem)
        {
            
        }

        public int PaginaAtual { get; set; }
        public int TotalPaginas => (int)Math.Ceiling(TotalItens / (double)TamanhoPagina);
        public int TamanhoPagina { get; set; } = Configuration.TamanhoPaginaPadrao;
        public int TotalItens { get; set; }
    }
}
