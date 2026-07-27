using Application.BoardingApp.BoardingServices;
using Application.BoardingApp.IBoardingRepos;
using Application.BoardingApp.IBoardingServices;
using Application.BreedApp.BreedServices;
using Application.BreedApp.IBreedRepos;
using Application.BreedApp.IBreedServices;
using Application.FoalingApp.FoalingServices;
using Application.FoalingApp.IFoalingRepos;
using Application.FoalingApp.IFoalingServices;
using Application.HorseApp.GenerateHorseInfo;
using Application.HorseApp.HorseServices;
using Application.HorseApp.IHorseRepos;
using Application.HorseApp.IHorseServices;
using Application.HorseApp.UpdateHorse;
using Application.OwnershipApp.EstateOwnershipApp.EstateOwnershipServices;
using Application.OwnershipApp.EstateOwnershipApp.IEstateOwnershipRepos;
using Application.OwnershipApp.EstateOwnershipApp.IEstateOwnershipServices;
using Application.OwnershipApp.HorseOwnershipApp.HorseOwnershipServices;
using Application.OwnershipApp.HorseOwnershipApp.IHorseOwnershipRepos;
using Application.OwnershipApp.HorseOwnershipApp.IHorseOwnershipServices;
using Application.SharedApp.BreedingServices;
using Application.SharedApp.FoalingHorseApp;
using Application.UnitOfWorks;
using Application.UserApp.IUserRepos;
using Application.UserApp.IUserServices.IUserCrudServices;
using Application.UserApp.UserSevices.UserCrudServices;
using Infrastructure;
using Infrastructure.Repositories.BoardingRepos;
using Infrastructure.Repositories.BreedRepos;
using Infrastructure.Repositories.FoalingRepos;
using Infrastructure.Repositories.HorseRepos;
using Infrastructure.Repositories.Ownership.EstateOwnerships;
using Infrastructure.Repositories.Ownership.HorseOwnerships;
using Infrastructure.Repositories.UserRepos;
using Infrastructure.UnitOfWorks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<NetEquusDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("Default"),
        sql => sql.EnableRetryOnFailure()
    ));

builder.Services.AddScoped<RandomHorseName>();
builder.Services.AddScoped<HorseGenderGenerator>();
builder.Services.AddScoped<RandomHorseBreed>();
builder.Services.AddScoped<HorseHeightGenerator>();
builder.Services.AddScoped<CalculateNextAgeingDate>();
builder.Services.AddScoped<IBreedListService, BreedListService>();

builder.Services.AddScoped<IFoalingCrudRepository, FoalingCrudRepository>();
builder.Services.AddScoped<IUserGetRepository, UserGetRepository>();
builder.Services.AddScoped<IFoalingHorseManagerService, FoalingHorseManagerService>();
builder.Services.AddScoped<IFoalingValidationService, FoalingValidationService>();
builder.Services.AddScoped<IBreedlistRepository, BreedListRepository>();
builder.Services.AddScoped<IEstateOwnershipGetService, EstateOwnershipGetService>();
builder.Services.AddScoped<IEstateOwnershipGetRepository, EstateOwnershipGetRepository>();

builder.Services.AddScoped<IHorseCrudRepository, HorseCrudRepository>();
builder.Services.AddScoped<IHorseGetRepository, HorseGetRepository>();
builder.Services.AddScoped<IUserGetService, UserGetService>();
builder.Services.AddScoped<IBreedGetRepository, BreedGetRepository>();
builder.Services.AddScoped<IBoardingCrudRepository, BoardingCrudRepository>();
builder.Services.AddScoped<IBoardingGetRepository, BoardingGetRepository>();
builder.Services.AddScoped<IHorseOwnershipGetRepository, HorseOwnershipGetRepository>();
builder.Services.AddScoped<IHorseOwnershipCrudRepository, HorseOwnershipCrudRepository>();
builder.Services.AddScoped<IFoalingCrudService, FoalingCrudService>();
builder.Services.AddScoped<IHorseInitilizationService, HorseInitilizationService>();
builder.Services.AddScoped<IHorseCrudService, HorseCrudService>();
builder.Services.AddScoped<IHorseOrchestrationService, HorseOrchestrationService>();
builder.Services.AddScoped<IHorseOwnershipCrudService, HorseOwnershipCrudService>();
builder.Services.AddScoped<IBoardingCrudService, BoardíngCrudService>();
builder.Services.AddScoped<IBreedGetService, BreedGetService>();
builder.Services.AddScoped<IBoardingGetService, BoardingGetService>();
builder.Services.AddScoped<IHorseGetService, HorseGetService>();
builder.Services.AddScoped<IHorseOwnershipOrchestrationService, HorseOwnershipOrchestrationService>();
builder.Services.AddScoped<IBoardingOrchestrationService, BoardingOrchestrationService>();
builder.Services.AddScoped<IFoalingHorseManagerService, FoalingHorseManagerService>();
builder.Services.AddScoped<IHorseGetService, HorseGetService>();
builder.Services.AddScoped<IHorseOwnershipGetService,  HorseOwnershipGetService>();

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