using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Money.Api.Common.Api;
using Money.Api.Data;
using Money.Api.Endpoints;
using Money.Api.Handlers;
using Money.Api.Models;
using Money.Core;
using Money.Core.Handlers;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

builder.AdicionarConfiguracao();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x => { x.CustomSchemaIds(n => n.FullName); });

builder.Services.AddAuthentication(IdentityConstants.ApplicationScheme).AddIdentityCookies();
builder.Services.AddAuthorization();

builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(Configuracao.StringDeConexao));

builder.Services.AddIdentityCore<User>()
    .AddRoles<IdentityRole<long>>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddApiEndpoints();

builder.Services.AddControllers();

builder.Services.AddTransient<ICategoriaHandler, CategoriaHandler>();
builder.Services.AddTransient<ITransacaoHandler, TransacaoHandler>();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.MapGet("/", () => new { mensagem = "Olá Mundo!" });
app.MapEndponts();

app.MapGroup("v1/identity")
    .WithTags("Identity")
    .MapIdentityApi<User>();

app.MapGroup("v1/identity")
    .WithTags("Identity")
    .MapPost("/logout", async (SignInManager<User> signInManager) =>
    {
        await signInManager.SignOutAsync();
        return Results.Ok();
    })
    .RequireAuthorization();

app.MapGroup("v1/identity")
    .WithTags("Identity")
    .MapGet("/roles", (ClaimsPrincipal user) =>
    {
        if (user.Identity is null || !user.Identity.IsAuthenticated)
           return Results.Unauthorized();

        var identity = (ClaimsIdentity)user.Identity;
        var roles = identity
            .FindAll(identity.RoleClaimType)
            .Select(c => new
            {
                c.Issuer,
                c.OriginalIssuer,
                c.Type,
                c.Value,
                c.ValueType
            });

        return TypedResults.Json(roles);
    })
    .RequireAuthorization();

app.Run();
