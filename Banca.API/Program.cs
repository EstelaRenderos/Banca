using Banca.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using FluentValidation.AspNetCore;
using Banca.Application.Services;
using Banca.Core.Interfaces;
using Banca.Infrastructure.Repositories;
using Banca.Application.Features.Auth.Commands.Login;
using MediatR;
using Banca.Infrastructure;
using Banca.Application;
using Banca.Infrastructure.Filters;
using Banca.Application.Services.TransactionService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();


// Registrar repositorios y servicios
builder.Services.AddScoped<IUserRepository, UserRepository>(); 
builder.Services.AddSingleton<AesEncryption>();
builder.Services.AddSingleton<HmacHelper>();

builder.Services.AddSingleton<JwtService>();
builder.Services.AddScoped<JwtAuthorizationFilter>();
builder.Services.AddScoped<ITransactionService, TransactionService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Base de datos
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));

// Registrar FluentValidation
builder.Services.AddControllers().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<LoginValidator>());


builder.Services.AddAuthorization();
builder.Services.AddScoped<JwtService>();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

// Configurar el pipeline de HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Mapear los controladores
app.MapControllers();

app.Run();