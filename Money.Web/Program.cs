using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Money.Web;
using Money.Web.Security;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//HttpClient Nativo
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

//Pacote Adicionado Microsoft.Extensions.Http
builder.Services.AddHttpClient(Configuracao.HttpClientName, opt => {
    opt.BaseAddress = new Uri(Configuracao.BackendUrl); 
}).AddHttpMessageHandler<CookieHandler>();

builder.Services.AddScoped<CookieHandler>();
builder.Services.AddMudServices();

await builder.Build().RunAsync();
