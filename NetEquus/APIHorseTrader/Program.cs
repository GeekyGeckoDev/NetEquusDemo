using Application.BoardingApp.BoardingServices;
using Application.BoardingApp.IBoardingRepos;
using Application.BoardingApp.IBoardingServices;
using Application.EconomyApp.HorseEconomyServices;
using Application.EstateApp.EstateServices;
using Application.EstateApp.EstateServices.EstateCrudServices;
using Application.EstateApp.IEstateRepos;
using Application.EstateApp.IEstateServices.IEstateCrudServices;
using Application.HorseApp;
using Application.HorseApp.HorseServices;
using Application.HorseApp.IHorseRepos;
using Application.HorseApp.IHorseServices;
using Application.OwnershipApp.EstateOwnershipApp.EstateOwnershipServices;
using Application.OwnershipApp.EstateOwnershipApp.IEstateOwnershipRepos;
using Application.OwnershipApp.EstateOwnershipApp.IEstateOwnershipServices;
using Application.OwnershipApp.HorseOwnershipApp.HorseOwnershipServices;
using Application.OwnershipApp.HorseOwnershipApp.IHorseOwnershipRepos;
using Application.OwnershipApp.HorseOwnershipApp.IHorseOwnershipServices;
using Application.SalesApp.HorseTraderSales;
using Application.SharedApp.HorseSaleApp;
using Application.SharedApp.HorseTraderDataServices;
using Application.UnitOfWorks;
using Application.UserApp.IUserRepo;
using Application.UserApp.IUserRepos;
using Application.UserApp.IUserServices;
using Application.UserApp.IUserServices.IUserCrudServices;
using Application.UserApp.NpcServices;
using Application.UserApp.UserServices;
using Application.UserApp.UserSevices.UserCrudServices;
using Infrastructure;
using Infrastructure.Repositories.BoardingRepos;
using Infrastructure.Repositories.EstateRepos;
using Infrastructure.Repositories.HorseRepos;
using Infrastructure.Repositories.Ownership.EstateOwnerships;
using Infrastructure.Repositories.Ownership.HorseOwnerships;
using Infrastructure.Repositories.SalesRepos;
using Infrastructure.Repositories.UserRepos;
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

builder.Services.AddScoped<IHorseTraderSaleRepository, HorseTraderSaleRepository>();
builder.Services.AddScoped<IUserGetRepository, UserGetRepository>();
builder.Services.AddScoped<IUserCrudRepository, UserCrudRepository>();
builder.Services.AddScoped<IBoardingGetRepository, BoardingGetRepository>();
builder.Services.AddScoped<IEstateOwnershipGetService, EstateOwnershipGetService>();
builder.Services.AddScoped<IEstateOwnershipGetRepository, EstateOwnershipGetRepository>();

builder.Services.AddScoped<IHorseTraderSaleInitilizationService, HorseTraderSaleInitilizationService>();
builder.Services.AddScoped<IHorseTraderSaleService, HorseTraderSaleService>();
builder.Services.AddScoped<IHorseTraderManagerService, HorseTraderManagerService>();

builder.Services.AddScoped<IUserGetService, UserGetService>();
builder.Services.AddScoped<IUserCrudService, UserCrudService>();
builder.Services.AddScoped<INpcGetService, NpcGetService>();
builder.Services.AddScoped<INpcManagerService, NpcManagerService>();
builder.Services.AddScoped<IHorseTraderDataService, HorseTraderDataService>();

builder.Services.AddScoped<IHorseRelations, HorseRelations>();
builder.Services.AddScoped<IBoardingCrudRepository,  BoardingCrudRepository>();
builder.Services.AddScoped<IBoardingCrudService, BoardíngCrudService>();
builder.Services.AddScoped<IBoardingGetService, BoardingGetService>();
builder.Services.AddScoped<IHorseOwnershipGetRepository, HorseOwnershipGetRepository>();
builder.Services.AddScoped<IHorseOwnershipCrudRepository, HorseOwnershipCrudRepository>();
builder.Services.AddScoped<IHorseOwnershipCrudService, HorseOwnershipCrudService>();
builder.Services.AddScoped<IHorseOwnershipGetService, HorseOwnershipGetService>();
builder.Services.AddScoped<IEstateGetRepository, EstateGetRepository>();
builder.Services.AddScoped<IEstateGetService, EstateGetService>();
builder.Services.AddScoped<IClientEstateCrudService, EstateClient>();
builder.Services.AddScoped<IEstateCrudRepository, EstateCrudRepository>();
builder.Services.AddScoped<INpcInitilizationService, NpcInitilizationService>();
builder.Services.AddScoped<IHorseGetService, HorseGetService>();
builder.Services.AddScoped<IHorseGetRepository, HorseGetRepository>();



builder.Services.AddScoped<IHorseEconomyService, HorseEconomyService>();


builder.Services.AddScoped<IHorseSaleManagerService, HorseSaleManagerService>();



builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


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