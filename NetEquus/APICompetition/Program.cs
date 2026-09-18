using Application.BreedApp.BreedServices;
using Application.BreedApp.BreedStatsApp;
using Application.BreedApp.IBreedRepos;
using Application.BreedApp.IBreedServices;
using Application.CompetitionApp.CompetitionDisciplineServices;
using Application.CompetitionApp.CompetitionServices;
using Application.CompetitionApp.ICompetitionDisciplineServices;
using Application.CompetitionApp.ICompetitionRepos;
using Application.CompetitionApp.ICompetitionServices;
using Application.UnitOfWorks;
using Infrastructure;
using Infrastructure.Repositories.BreedRepos;
using Infrastructure.Repositories.BreedRepos.BreedStatsRepos;
using Infrastructure.Repositories.CompetitionsRepos;
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

builder.Services.AddScoped<ICompetitionClassCrudRepository, CompetitionClassCrudRepository>();
builder.Services.AddScoped<ICompetitionStatRequirementRepository, CompetitionStatRequirementRepository>();
builder.Services.AddScoped<ICompetitionDisciplineRepository, CompetitionDisciplineRepository>();
builder.Services.AddScoped<ICompetitionCrudRepository, CompetitionCrudRepository>();
builder.Services.AddScoped<ICompetitionEntryCrudRepository, CompetitionEntryCrudRepository>();
builder.Services.AddScoped<ICompetitionResultCrudRepository, CompetitionResultCrudRepository>();

builder.Services.AddScoped<ICompetitionClassCrudService, CompetitionClassCrudService>();
builder.Services.AddScoped<ICompetitionStatRequirementService, CompetitionStatRequirementService>();
builder.Services.AddScoped<ICompetitionDisicplineService, CompetitionDisicplineService>();
builder.Services.AddScoped<ICompetitionCrudService, CompetitionCrudService>();
builder.Services.AddScoped<ICompetitionEntryCrudService, CompetitionEntryService>();
builder.Services.AddScoped<ICompetitionResultCrudService, CompetitionResultCrudService>();

builder.Services.AddScoped<ICompetitionDisciplineClassManager, CompetitionDisciplineClassManager>();

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