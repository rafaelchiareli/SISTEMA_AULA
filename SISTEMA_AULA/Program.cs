using Microsoft.EntityFrameworkCore;
using SISTEMA_AULA.MODEL.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DbsistemasContext>(opt => opt.UseSqlServer("Server=.\\SQLExpress;Database=DBSISTEMAS;Trusted_Connection=True;trustservercertificate=true"));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
