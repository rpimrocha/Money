namespace Money.Core
{
    public abstract class Configuracao
    {
        public const int CodigoStatusPadrao = 200;
        public const int PaginaNumeroPadrao = 1;
        public const int TamanhoPaginaPadrao = 25;

        public static string StringDeConexao { get; set; } = string.Empty;
    }
}
