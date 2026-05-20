using Microsoft.AspNetCore.Components.Authorization;

namespace Money.Web.Security
{
    public interface ICookieEstadoAutenticacaoProvider
    {
        Task<bool> UsuarioAutenticadoAsync();
        Task<AuthenticationState> GetAuthenticationStateAsync();
        void NotificarMudancaEstadoAutenticacao();
    }
}
