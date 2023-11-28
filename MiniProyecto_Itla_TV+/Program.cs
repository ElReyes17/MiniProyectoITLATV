using Application.Interfaces.Repositorios;
using Application.Interfaces.Servicios;
using Application.Repositorios;
using Application.Servicios;
using DataBase;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var conn = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddDbContext<TVContext>(op => op.UseSqlServer(conn));

builder.Services.AddScoped(typeof(IMantenimientoRepositorio<>), typeof(MantenimientoRepostorio<>));

builder.Services.AddScoped<IProductoraRepositorio,RepositorioProductoras>();
builder.Services.AddScoped<IServiciosProductoras, ServiciosProductoras>();

builder.Services.AddScoped<IGeneroRepositorio, RepositorioGeneros>();
builder.Services.AddScoped<IServiciosGeneros, ServiciosGeneros>();

builder.Services.AddScoped<ISerieRepositorio, RepositorioSeries>();
builder.Services.AddScoped<IServiciosSeries, ServiciosSeries>();

builder.Services.AddScoped<ISeriesGenerosRepositorio, SeriesGenerosRepositorio>();
builder.Services.AddScoped<IServiciosSeriesGeneros, ServiciosSeriesGeneros>();

var app = builder.Build();

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
