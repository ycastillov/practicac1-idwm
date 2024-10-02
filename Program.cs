using EjemploApiC1.src.Models.Data;
using Microsoft.EntityFrameworkCore;
using practica1.src.Data;
using practica1.src.Interfaces;
using practica1.src.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext> (options => options.UseSqlite("Data Source=Practica1.db"));

builder.Services.AddControllers();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

var app = builder.Build();

app.MapControllers();

using (var scope = app.Services.CreateScope()) // Se levanta la base de datos
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<DataContext>(); // Obtener servicio 
    await context.Database.MigrateAsync(); // Se realiza la migración de la base de datos de forma asincrona
    await Seeder.Seed(context);
}

app.Run();


