using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using cuentamovimiento.Entities;
using cuentamovimiento.Data;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;  // Agrega esta directiva



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Configurar DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 21))));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
