using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApplication4.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<WebApplication4Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WebApplication4Context") ?? throw new InvalidOperationException("Connection string 'WebApplication4Context' not found.")));

builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.MapDefaultEndpoints();

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
