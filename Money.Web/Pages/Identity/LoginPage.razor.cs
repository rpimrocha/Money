using Microsoft.AspNetCore.Components;
using Money.Core.Handlers;
using Money.Core.Requests.Account;
using Money.Web.Security;
using MudBlazor;

namespace Money.Web.Pages.Identity
{
    public partial class LoginPage : ComponentBase
    {
        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        [Inject]
        public IAccountHandler AccountHandler { get; set; } = null!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        [Inject]
        public ICookieEstadoAutenticacaoProvider AuthenticationStateProvider { get; set; } = null!;


        public bool IsLoading { get; set; } = false;
        public LoginRequest LoginRequest { get; set; } = new LoginRequest();


        override protected async Task OnInitializedAsync()
        {
            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;

            if (user?.Identity?.IsAuthenticated == true)
                NavigationManager.NavigateTo("/");
        }

        public async Task LoginAsync()
        {
            IsLoading = true;
            try
            {
                var response = await AccountHandler.LoginAsync(LoginRequest);
                if (response.IsSuccess)
                {
                    await AuthenticationStateProvider.GetAuthenticationStateAsync();
                    AuthenticationStateProvider.NotificarMudancaEstadoAutenticacao();
                    NavigationManager.NavigateTo("/");
                }
                else
                {
                    Snackbar.Add(response.Mensagem, Severity.Warning);
                }
            }
            catch (Exception ex)
            {
                Snackbar.Add($"Ocorreu um erro: {ex.Message}", Severity.Error);
            }
            finally
            {
                IsLoading = false;
            }
        }
    }
}
