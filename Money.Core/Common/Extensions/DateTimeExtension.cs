using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money.Core.Common.Extensions
{
    public static class DateTimeExtension
    {
        public static DateTime PrimeiroDia(this DateTime data, int? ano = null, int? mes = null)
            => new(ano ?? data.Year, mes ?? data.Month, 1);


        public static DateTime UltimoDia(this DateTime data, int? ano = null, int? mes = null)
            => new(ano ?? data.Year, mes ?? data.Month, DateTime.DaysInMonth(ano ?? data.Year, mes ?? data.Month));
    }
}
