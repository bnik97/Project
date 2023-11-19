using Microsoft.Extensions.Configuration;
using WebApplication2.Models;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Services;
using WebApplication2.Models.repositories;
using System.Globalization;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<EarthquakeService>();
builder.Services.AddScoped<EarthquakeRepository>();
builder.Services.AddHostedService<EarthquakeGeneratorService>();

var app = builder.Build();


var defaultCulture = new CultureInfo("en-US");
defaultCulture.NumberFormat.NumberDecimalSeparator = ".";

app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture(defaultCulture),
    SupportedCultures = new List<CultureInfo> { defaultCulture },
    SupportedUICultures = new List<CultureInfo> { defaultCulture }
});

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "earthquakes",
    pattern: "{action=Index}/{id?}",
    defaults: new { controller = "Earthquakes" });
app.Run();
