using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using AppDotacion.Data;

var builder = WebApplication.CreateBuilder(args);

// Configuraci�n de servicios en la aplicaci�n
builder.Services.AddDbContext<AppDotacionContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Agregar servicios necesarios para Razor Pages
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configuraci�n del pipeline de la aplicaci�n HTTP
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dotaciones}/{action=Index}/{id?}");

app.Run();
