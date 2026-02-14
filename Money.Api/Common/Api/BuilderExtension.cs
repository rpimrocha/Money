using Money.Core;

namespace Money.Api.Common.Api
{
    public static class BuilderExtension
    {
        public static void AdicionarConfiguracao(this WebApplicationBuilder builder)
        {
            Configuracao.StringDeConexao = builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
        }
    }
}
