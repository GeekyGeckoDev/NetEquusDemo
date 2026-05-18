using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components.Authorization;
using UI.API.ApiClients;
using UI.API.Clients;
using UI.API.Services;
using UI.Auth;
using UI.Components;
using UI.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();

builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<AuthManager>();
builder.Services.AddScoped<GetNpcsAndEstates>();

builder.Services.AddScoped<CustomAuthStateProvider>();

builder.Services.AddScoped<AuthenticationStateProvider>(provider =>
    provider.GetRequiredService<CustomAuthStateProvider>());

var authBase = builder.Configuration["ApiSettings:AuthBaseUrl"];
var estateBase = builder.Configuration["ApiSettings:EstateBaseUrl"];
var artistBase = builder.Configuration["ApiSettings:ArtistBaseUrl"];
var breedBase = builder.Configuration["ApiSettings:BreedBaseUrl"];
var horseBase = builder.Configuration["ApiSettings:HorseBaseUrl"];


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

builder.Services.AddHttpClient<NpcClient>(c =>
{
    c.BaseAddress = new Uri(authBase);
})
.AddHttpMessageHandler<AuthHeaderHandler>();

builder.Services.AddHttpClient<ArtistClient>(c =>
{ c.BaseAddress = new Uri(artistBase);
})
.AddHttpMessageHandler<AuthHeaderHandler>();

builder.Services.AddHttpClient<AdminArtistClient>(c =>
{
    c.BaseAddress = new Uri(artistBase);
})
.AddHttpMessageHandler<AuthHeaderHandler>();

builder.Services.AddHttpClient<BreedClient>(c 
    => c.BaseAddress = new Uri(breedBase));

builder.Services.AddHttpClient<HorseClient>(c =>
{
    c.BaseAddress = new Uri(horseBase);
})
    .AddHttpMessageHandler<AuthHeaderHandler>();

builder.Services.AddHttpClient<BoardingClient>(c =>
{
    c.BaseAddress = new Uri(horseBase);
})
    .AddHttpMessageHandler<AuthHeaderHandler>();

builder.Services.AddHttpClient<EstateOwnershipClient>(c =>
{
    c.BaseAddress = new Uri(estateBase);
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