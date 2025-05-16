using Microsoft.EntityFrameworkCore;
using Omine.Domain.Service;
using Omine.Infra;
using Omine.Infra.Interface;
using Omine.Infra.Repositorio;

var builder = WebApplication.CreateBuilder(args);

// Add Services Omine
builder.Services.AddDbContext<OmineContext>(
    options => options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// Registrar o Repositório Genérico
builder.Services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));


// Registrar o Serviço Genérico
builder.Services.AddScoped(typeof(Service<,>), typeof(Service<,>));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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