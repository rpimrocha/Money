using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Money.Api.Data;
using Money.Api.Endpoints;
using Money.Api.Handlers;
using Money.Api.Models;
using Money.Core.Handlers;

var builder = WebApplication.CreateBuilder(args);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x => { x.CustomSchemaIds(n => n.FullName); });

builder.Services.AddAuthentication(IdentityConstants.ApplicationScheme).AddIdentityCookies();
builder.Services.AddAuthorization();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(connectionString));

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

app.Run();
