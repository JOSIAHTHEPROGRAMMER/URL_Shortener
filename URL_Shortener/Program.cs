using Microsoft.EntityFrameworkCore;
using NetcodeHub.Packages.Extensions.Clipboard;
using URL_Shortener.Components;
using URL_Shortener.helper;
using URL_Shortener.Repository;
using URL_Shortener.Services;
using URL_Shortener.URLData;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<URLDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("Sqlite")));

builder.Services.AddScoped<InterfaceURLRepository, URLRepo>();
builder.Services.AddScoped<IHelper, Helper>();
builder.Services.AddScoped<IService, UrlService>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddNetcodeHubClipboardService();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.MapGet("/{shortCode}", async (string shortCode, IService UrlService) =>
{
    var res = await UrlService.GetOriginalAsync(shortCode);
    return res == string.Empty? Results.NotFound() : Results.Redirect(res!);
});

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
