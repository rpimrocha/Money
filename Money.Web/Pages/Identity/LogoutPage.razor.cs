using Microsoft.AspNetCore.Components;
using Money.Core.Handlers;
using Money.Web.Security;
using MudBlazor;

namespace Money.Web.Pages.Identity
{
    public partial class LogoutPage : ComponentBase
    {
        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        [Inject]
        public IAccountHandler AccountHandler { get; set; } = null!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        [Inject]
        public ICookieEstadoAutenticacaoProvider AuthenticationStateProvider { get; set; } = null!;


        protected override async Task OnInitializedAsync()
        {
            if (await AuthenticationStateProvider.UsuarioAutenticadoAsync())
            {
                await AccountHandler.LogoutAsync();
                await AuthenticationStateProvider.GetAuthenticationStateAsync();
                AuthenticationStateProvider.NotificarMudancaEstadoAutenticacao();

                Snackbar.Add("Logout realizado com sucesso!", Severity.Success);
                //NavigationManager.NavigateTo("/login");
            }

            await base.OnInitializedAsync();
        }
    }
}