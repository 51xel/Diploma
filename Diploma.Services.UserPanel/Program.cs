using Azure.Extensions.AspNetCore.Configuration.Secrets;
using Azure.Identity;
using Blazorise;
using Blazorise.Bootstrap5;
using Blazorise.Icons.FontAwesome;
using Blazorise.LoadingIndicator;
using Diploma.Application;
using Diploma.Application.Users.Interfaces;
using Diploma.Dal.EntityFramework;
using Diploma.Dal.HttpClient;
using Diploma.Dal.MemoryCache;
using Diploma.Dal.PythonRunTime;
using Diploma.Dal.Storage;
using Diploma.Services.UserPanel.Common;
using Diploma.Services.UserPanel.Components;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddAzureKeyVault(
    new Uri(builder.Configuration["AzureKeyVaultUri"]!),
    new DefaultAzureCredential(),
    new AzureKeyVaultConfigurationOptions
    {
        Manager = new KeyVaultSecretManager()
    });

builder.Services
    .AddApplication()
    .AddDalEntityFramework(builder.Configuration)
    .AddDalStorage(builder.Configuration)
    .AddDalPythonRunTime()
    .AddDalMemorysCache()
    .AddDalHttpClient(builder.Configuration);

builder.Services.AddSingleton<IPasswordHasher, PasswordHasher>();
builder.Services.AddScoped<AccountHelper>();

builder.Services
    .AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options => 
    {
        options.Cookie.Name = "auth_token";
        options.LoginPath = "/login";
        options.Cookie.MaxAge = TimeSpan.FromMinutes(30);
        options.AccessDeniedPath = "/access-denied";
    });

builder.Services
    .AddAuthorization()
    .AddCascadingAuthenticationState()
    .AddHttpContextAccessor();

builder.Services
    .AddBlazorise(options =>
    {
        options.Immediate = true;
    })
    .AddBootstrap5Providers()
    .AddFontAwesomeIcons()
    .AddLoadingIndicator();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
