namespace Money.Core.Models.Relatorios;
public record ResultadoFinanceiro(string CodigoUsuario, decimal Receitas, decimal Despesas)
{
    public decimal Total => Receitas - (Despesas < 0 ? -Despesas : Despesas);
}
