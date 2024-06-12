using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using WebSales.Data;
using WebSales.Services;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<WebSalesContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("WebSalesContext"),
        Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.34-mysql")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<SellerService>();
builder.Services.AddScoped<DepartmentService>();
builder.Services.AddScoped<SalesRecordService>();

var app = builder.Build();

// Configure Culture Info
var ptBR = new CultureInfo("pt-BR");
var enUS = new CultureInfo("en-US");
var localizationOptions = new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture(ptBR),
    SupportedCultures = new List<CultureInfo> { ptBR, enUS },
    SupportedUICultures = new List<CultureInfo> { ptBR, enUS }
};

app.UseRequestLocalization(localizationOptions);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
