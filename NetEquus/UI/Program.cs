using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components.Authorization;
using UI.API.ApiClients;
using UI.API.Clients;
using UI.Auth;
using UI.Components;
using UI.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var apiBase = builder.Configuration["ApiSettings:BaseUrl"]
    ?? throw new Exception("Api BaseUrl is missing from appsettings.json");

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "BlazorAuth";
    options.DefaultChallengeScheme = "BlazorAuth";
}).AddScheme<AuthenticationSchemeOptions, BlazorAuthHandler>("BlazorAuth", null);
builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();

builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<AuthManager>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();

builder.Services.AddApiClientWithCookies<AuthClient>(apiBase);
builder.Services.AddApiClientWithCookies<RegisterClient>(apiBase);

var app = builder.Build();

// --------------------
// HTTP pipeline (ORDER MATTERS)
// --------------------

app.UseHttpsRedirection();

app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);

app.UseAntiforgery();

app.MapStaticAssets();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();