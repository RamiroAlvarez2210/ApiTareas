
using Domain.Repositories;
using Infraestructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Application.Services;
using Application.Dtos;
using Application.Mappers;




var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<TareasDbContext>(
    options => options.UseSqlite(builder.Configuration.GetConnectionString("Default")));

// Servicios de Aplicación (GenericService con tipos cerrados)
builder.Services.AddScoped<IGenericService<UsuarioDto>, GenericService<Usuario, UsuarioDto>>();
builder.Services.AddScoped<IGenericService<EquipoDto>, GenericService<Equipo, EquipoDto>>();

builder.Services.AddScoped<AsignacionService>();
builder.Services.AddScoped<IGenericService<AsignacionDto>>(provider => provider.GetRequiredService<AsignacionService>());

builder.Services.AddScoped<IGenericService<TareaDto>, TareaService>();


// Mappers (Registrar cada implementación específica)
builder.Services.AddScoped<IMapper<Usuario, UsuarioDto>, UsuarioMapper>();
builder.Services.AddScoped<IMapper<Tarea, TareaDto>, TareaMapper>();
builder.Services.AddScoped<IMapper<Equipo, EquipoDto>, EquipoMapper>();
builder.Services.AddScoped<IMapper<Asignacion, AsignacionDto>, AsignacionMapper>();


builder.Services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
builder.Services.AddScoped<IUsuarioRepository<Usuario>, UsuarioRepository>();
builder.Services.AddScoped<IEquipoRepository<Equipo>, EquipoRepository>();

// Agrega servicios Swagger
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.UseHttpsRedirection();

app.Run();
