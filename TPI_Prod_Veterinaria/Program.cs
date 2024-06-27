using Application.Interfaces;
using Application.Services;
using Domain.IRepository;
using Infra.Data;
using Infra.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlite(
builder.Configuration["ConnectionStrings:DBConnectionString"], b => b.MigrationsAssembly("Infra")));


#region INYECCIONES
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IVeteServices, VeteServices>();
builder.Services.AddScoped<IVeteRepository, VeteRepository>();
#endregion



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
