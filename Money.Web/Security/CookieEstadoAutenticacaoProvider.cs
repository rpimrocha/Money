using Microsoft.AspNetCore.Components.Authorization;
using Money.Core.Models.Account;
using System.Net.Http.Json;
using System.Security.Claims;

namespace Money.Web.Security
{
    public class CookieEstadoAutenticacaoProvider(IHttpClientFactory httpClientFactory) : AuthenticationStateProvider, ICookieEstadoAutenticacaoProvider
    {
        private bool _usuarioAutenticado = false;
        private readonly HttpClient _httpClient = httpClientFactory.CreateClient(Configuracao.HttpClientName);

        public async Task<bool> UsuarioAutenticadoAsync()
        {
            await GetAuthenticationStateAsync();
            return _usuarioAutenticado;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            _usuarioAutenticado = false;
            var user = new ClaimsPrincipal(new ClaimsIdentity());

            var usuario = await ObterUsuario();
            if (usuario is null)
                return new AuthenticationState(user);

            var claims = await ObterClaims(usuario);
            var claimsIdentity = new ClaimsIdentity(claims, nameof(CookieEstadoAutenticacaoProvider));
            user = new ClaimsPrincipal(claimsIdentity);

            _usuarioAutenticado = true;
            return new AuthenticationState(user);
        }

        public void NotificarMudancaEstadoAutenticacao()
        {
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        private async Task<User?> ObterUsuario()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<User?>("v1/identity/manage/info");
            }
            catch
            {
                return null;
            }
        }

        private async Task<List<Claim>> ObterClaims(User user)
        {
            var claims = new List<Claim>
            {
                new (ClaimTypes.Name, user.Email),
                new (ClaimTypes.Email, user.Email)
            };

            claims.AddRange(user.Claims
                .Where(c => c.Key != ClaimTypes.Name && c.Key != ClaimTypes.Email)
                .Select(c => new Claim(c.Key, c.Value))
            );

            RoleClaim[]? roles;
            try
            {
                roles = await _httpClient.GetFromJsonAsync<RoleClaim[]>("v1/identity/roles");
            }
            catch
            {
                return claims;
            }

            foreach (var role in roles ?? [])
            {
                if (!string.IsNullOrEmpty(role.Type) && !string.IsNullOrEmpty(role.Value))
                    claims.Add(new Claim(role.Type, role.Value, role.ValueType, role.Issuer, role.OriginalIssuer));
            }

            return claims;
        }
    }
}
