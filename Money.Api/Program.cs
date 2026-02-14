using Money.Api.Common.Api;
using Money.Api.Endpoints;
using Money.Core;

var builder = WebApplication.CreateBuilder(args);

builder.AdicionarConfiguracao();
builder.AdicionarSeguranca();
builder.AdicionarDataContexts();
builder.AdicionarCrossOrigin();
builder.AdicionarSwagger();
builder.AdicionarServicos();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.AtivarSwagger();
}

app.UseCors(Configuracao.NomeDaPoliticaDoCors);

app.AtivarSeguranca();
app.MapearEndponts();

app.Run();
