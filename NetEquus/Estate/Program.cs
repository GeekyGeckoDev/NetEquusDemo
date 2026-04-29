using Application.EstateApp.EstateServices;
using Application.EstateApp.EstateServices.EstateCrudServices;
using Application.EstateApp.EstateServices.EstateManagerServices;
using Application.EstateApp.EstateServices.EstateOrchestrationServices;
using Application.EstateApp.EstateServices.EstateValidationService;
using Application.EstateApp.IEstateRepos;
using Application.EstateApp.IEstateServices;
using Application.EstateApp.IEstateServices.IEstateCrudServices;
using Application.EstateApp.IEstateServices.IEstateOrchestrationServices;
using Application.EstateApp.IEstateServices.IEstateValidationServices;
using Application.SharedApp.IOwnershipRepos;
using Application.SharedApp.IOwnershipServices;
using Application.SharedApp.OwnershipServices;
using Application.UnitOfWorks;
using Infrastructure;
using Infrastructure.Repositories.EstateRepos;
using Infrastructure.Repositories.SharedRepos;
using Infrastructure.UnitOfWorks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<NetEquusDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("Default"),
        sql => sql.EnableRetryOnFailure()
    ));


builder.Services.AddScoped<IEstateCrudRepository, EstateCrudRepository>();
builder.Services.AddScoped<IEstateGetRepository, EstateGetRepository>();
builder.Services.AddScoped<IEstateValidationRepository, EstateValidationRepository>();
builder.Services.AddScoped<IEstateOwnersipCrudRepository, EstateOwnershipCrudRepository>();
builder.Services.AddScoped<IEstateOwnershipGetRepository, EstateOwnershipGetRepository>();
builder.Services.AddScoped<IEstateOwnershipValidationRepository, EstateOwnershipValidationRepository>();

// ---------------------------
// Estate services
// ---------------------------
builder.Services.AddScoped<IAdminEstateCrudService, EstateAdmin>();
builder.Services.AddScoped<IClientEstateCrudService, EstateClient>();
builder.Services.AddScoped<IEstateGetService, EstateGetService>();
builder.Services.AddScoped<IEstateOrchestrationService, EstateOrchestrationService>();
builder.Services.AddScoped<IEstateOrchestrationValidationService, EstateOrchestrationValidationService>();
builder.Services.AddScoped<IEstateValidationService, EstateValidationService>();
builder.Services.AddScoped<IEstateInitilizationService, EstateInitilizationService>();
builder.Services.AddScoped<IEstateOwnershipCrudService, EstateOwnershipCrudService>();
builder.Services.AddScoped<IEstateOwnershipGetService, EstateOwnershipGetService>();
builder.Services.AddScoped<IEstateOwnershipOrchestrationService, EstateOwnershipOrchestrationService>();
builder.Services.AddScoped<IEstateOwnershipValidationService, EstateOwnershipValidationService>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// ---------------------------
// Estate services
// ---------------------------



builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowUI", policy =>
    {
        policy.WithOrigins("https://localhost:7167", "http://localhost:5142")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddControllers();

builder.Services.AddAuthentication()
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
        };

        options.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                context.Token = context.Request.Cookies["accessToken"];
                return Task.CompletedTask;
            }
        };
    });

builder.Services.AddAuthorization();

var app = builder.Build();

// --------------------
// Pipeline (ORDER MATTERS)
// --------------------



if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseCors("AllowUI");

app.UseAuthentication();   // ❗ REQUIRED (you are missing this)
app.UseAuthorization();

// Controllers
app.MapControllers();

app.Run();