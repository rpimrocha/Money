namespace Money.Core.Models
{
    public class Categoria
    {
        public long Codigo { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string CodigoUsuario { get; set; } = string.Empty;
    }
}
