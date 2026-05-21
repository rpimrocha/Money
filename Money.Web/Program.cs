using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Money.Core.Handlers;
using Money.Web;
using Money.Web.Handlers;
using Money.Web.Security;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

Configuracao.BackendUrl = builder.Configuration.GetValue<string>("BackendUrl") ?? string.Empty;

builder.Services.AddScoped<CookieHandler>();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CookieEstadoAutenticacaoProvider>();
builder.Services.AddScoped(x => (ICookieEstadoAutenticacaoProvider)x.GetRequiredService<AuthenticationStateProvider>()); 
builder.Services.AddMudServices();

//HttpClient Nativo
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

//Pacote Adicionado Microsoft.Extensions.Http
builder.Services.AddHttpClient(Configuracao.HttpClientName, opt => {
    opt.BaseAddress = new Uri(Configuracao.BackendUrl); 
}).AddHttpMessageHandler<CookieHandler>();

builder.Services.AddTransient<IAccountHandler, AccountHandler>();

await builder.Build().RunAsync();
