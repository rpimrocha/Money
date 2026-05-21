using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Money.Core.Handlers;
using Money.Core.Requests.Account;
using MudBlazor;

namespace Money.Web.Pages.Identity
{
    public partial class RegistroPage : ComponentBase
    {
        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        [Inject]
        public IAccountHandler AccountHandler { get; set; } = null!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        [Inject]
        public AuthenticationStateProvider AuthenticationStateProvider { get; set; } = null!;


        public bool IsLoading { get; set; } = false;
        public RegistroRequest RegistroRequest { get; set; } = new RegistroRequest();


        override protected async Task OnInitializedAsync()
        {
            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;

            if (user?.Identity?.IsAuthenticated == true)
                NavigationManager.NavigateTo("/");
        }

        public async Task RegistrarAsync()
        {
            IsLoading = true;

            try
            {
                var response = await AccountHandler.RegistrarAsync(RegistroRequest);
                if (response.IsSuccess)
                {
                    Snackbar.Add("Registro realizado com sucesso!", Severity.Success);
                    NavigationManager.NavigateTo("/login");
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
    