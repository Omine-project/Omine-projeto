using Microsoft.EntityFrameworkCore;
using Omine.Domain.Interface;
using Omine.Domain.Service;
using Omine.Infra;
using Omine.Infra.Interface;
using Omine.Infra.Repositorio;

var builder = WebApplication.CreateBuilder(args);

// Add Services Omine
builder.Services.AddDbContext<OmineContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registrar o Repositório Genérico
builder.Services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
builder.Services.AddScoped(typeof(ICompositeRepository<>), typeof(CompositeRepository<>));

// Registrar o Serviço Genérico
builder.Services.AddScoped(typeof(Service<,>), typeof(Service<,>));

// Registrar serviços específicos
builder.Services.AddScoped<AnimeService>();
builder.Services.AddScoped<AnimeListaService>();
builder.Services.AddScoped<AnimeGeneroService>();
builder.Services.AddScoped<ComentarioService>();
builder.Services.AddScoped<ListaService>();
builder.Services.AddScoped<GeneroService>();
builder.Services.AddScoped<UsuarioService>();

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
