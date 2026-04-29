using Application.AuthApp.AuthServices;
using Application.AuthApp.IAuthServices;
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
using Application.UserApp.IUserRepo;
using Application.UserApp.IUserRepos;
using Application.UserApp.IUserServices;
using Application.UserApp.IUserServices.IUserCrudServices;
using Application.UserApp.IUserServices.IUserValidationServices;
using Application.UserApp.UserServices;
using Application.UserApp.UserSevices.UserCrudServices;
using Application.UserApp.UserSevices.UserManagerServices;
using Application.UserApp.UserSevices.UserValidationServices;
using Application.UserSessionApp;
using Infrastructure;
using Infrastructure.Repositories.EstateRepos;
using Infrastructure.Repositories.SharedRepos;
using Infrastructure.Repositories.UserRepos;
using Infrastructure.UnitOfWorks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using UI.Components;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<NetEquusDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("Default"),
        sql => sql.EnableRetryOnFailure()
    ));
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

//Service injections

builder.Services.AddScoped<IUserCrudService, UserCrudService>();
builder.Services.AddScoped<IUserGetService, UserGetService>();
builder.Services.AddScoped<IUserManagerService, UserManagerService>();

builder.Services.AddScoped<IEmailValidationService, EmailValidationService>();
builder.Services.AddScoped<IPasswordValidationService, PasswordValidationService>();
builder.Services.AddScoped<IRegistrationValidationService, RegistrationValidationService>();

builder.Services.AddScoped<IJWTService, JWTService>();
builder.Services.AddScoped<ILogInService, LogInService>();
builder.Services.AddScoped<IPasswordHasherService, PasswordHasherService>();

builder.Services.AddScoped<IEstateGetRepository, EstateGetRepository>();
builder.Services.AddScoped<IEstateOwnershipGetRepository, EstateOwnershipGetRepository>();
builder.Services.AddScoped<IUserSessionService, UserSessionService>();


// ---------------------------
// Estate services
// ---------------------------


builder.Services.AddScoped<IEstateGetService, EstateGetService>();
builder.Services.AddScoped<IEstateOwnershipGetService, EstateOwnershipGetService>();


builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//Repository injections

builder.Services.AddScoped<IUserCrudRepository, UserCrudRepository>();
builder.Services.AddScoped<IUserGetRepository,  UserGetRepository>();
builder.Services.AddScoped<IUserValidationRepository, UserValidationRepository>();

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