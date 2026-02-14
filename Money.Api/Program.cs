using Microsoft.AspNetCore.Identity;
using Money.Api.Common.Api;
using Money.Api.Endpoints;
using Money.Api.Models;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

builder.AdicionarConfiguration();
builder.AdicionarSecurity();
builder.AdicionarDataContexts();
builder.AdicionarCrossOrigin();
builder.AdicionarSwagger();
builder.AdicionarServices();

builder.Services.AddControllers();

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
