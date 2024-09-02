using escuelaAPI.Data;
using escuelaAPI.Repository.IRepository;
using escuelaAPI.Repository;
using Microsoft.EntityFrameworkCore;
using escuelaAPI.Configurations;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSQLConnection"));
});

//Repository
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IAlumnoRepository, AlumnoRepository>();
builder.Services.AddScoped<IEscuelaRepository, EscuelaRepository>();
builder.Services.AddScoped<IGrupoRepository, GrupoRepository>();
builder.Services.AddScoped<IEmpleadoRepository, EmpleadoRepository>();
builder.Services.AddScoped<IEstadoRepository, EstadoRepository>();
//Mapper
builder.Services.AddAutoMapper(
    typeof(RoleMapperConfig),
    typeof(AlumnoMapperConfig),
    typeof(EscuelaMapperConfig),
    typeof(GrupoMapperConfig),
    typeof(RoleMapperConfig),
    typeof(EstadoMapperConfig)
    );
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddCors(options =>
    options.AddDefaultPolicy( // This is the open house we talked about!
        builder =>
        {
            builder.AllowAnyOrigin() // Any origin is welcome...
                .AllowAnyHeader() // With any type of headers...
                .AllowAnyMethod()
                .WithExposedHeaders("X-Pagination"); // And any HTTP methods. Such a jolly party indeed!
        })
);
var app = builder.Build();
app.UseCors();
//conect to db
//AUX CORS



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
