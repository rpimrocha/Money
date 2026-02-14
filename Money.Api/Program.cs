using Money.Api.Common.Api;
using Money.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.AdicionarAuthentication();
builder.AdicionarSecurity();
builder.AdicionarDataContexts();
builder.AdicionarCrossOrigin();
builder.AdicionarSwagger();
builder.AdicionarServices();

//builder.Services.AddControllers();

var app = builder.Build();



if (app.Environment.IsDevelopment())
{
    app.AtivarSwagger();
}

//app.MapControllers();

app.AtivarAuthentication();
app.MapearEndponts();

app.Run();
