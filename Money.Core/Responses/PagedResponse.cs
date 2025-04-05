using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks; 

namespace Money.Core.Responses
{
    public class PagedResponse<TDado> : Response<TDado>
    {
        [JsonConstructor]
        public PagedResponse(TDado? dado, int totalItens, int paginaAtual = Configuracao.PaginaNumeroPadrao, 
            int tamanhoPagina = Configuracao.TamanhoPaginaPadrao) : base(dado)
        {
            Dado = dado;
            TotalItens = totalItens;
            PaginaAtual = paginaAtual;
            TamanhoPagina = tamanhoPagina;
        }

        public PagedResponse(TDado? dado, int codigoStatus = Configuracao.CodigoStatusPadrao, 
            string? mensagem = null) : base(dado, codigoStatus, mensagem)
        {
            
        }

        public int PaginaAtual { get; set; }
        public int TotalPaginas => (int)Math.Ceiling(TotalItens / (double)TamanhoPagina);
        public int TamanhoPagina { get; set; } = Configuracao.TamanhoPaginaPadrao;
        public int TotalItens { get; set; }
    }
}
