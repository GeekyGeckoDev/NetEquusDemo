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

var authBase = builder.Configuration["ApiSettings:AuthBaseUrl"];
var estateBase = builder.Configuration["ApiSettings:EstateBaseUrl"];
var artistBase = builder.Configuration["ApiSettings:HorseArtistUrl"];


builder.Services.AddSingleton<ITokenStore, TokenStore>();
builder.Services.AddTransient<AuthHeaderHandler>();

builder.Services.AddHttpClient<EstateClient>(c =>
{
    c.BaseAddress = new Uri(estateBase);
})
.AddHttpMessageHandler<AuthHeaderHandler>();

builder.Services.AddHttpClient<AuthClient>(c =>
{
    c.BaseAddress = new Uri(authBase);
})
.AddHttpMessageHandler<AuthHeaderHandler>();

builder.Services.AddHttpClient<RegisterClient>(c =>
{
    c.BaseAddress = new Uri(authBase);
})
.AddHttpMessageHandler<AuthHeaderHandler>();

builder.Services.AddHttpClient<HorseArtistClient>(c =>
{ c.BaseAddress = new Uri(artistBase);
})
.AddHttpMessageHandler<AuthHeaderHandler>();

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