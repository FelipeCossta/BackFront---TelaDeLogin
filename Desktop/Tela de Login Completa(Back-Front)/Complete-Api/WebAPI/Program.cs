using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Repos;
using WebAPI.Repos.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

var connectionString = builder.Configuration.GetConnectionString("Database");

builder.Services.AddEntityFrameworkMySql().AddDbContext<UsuariosContext>(
    options => options.UseMySql(connectionString,  ServerVersion.AutoDetect(connectionString))
);

builder.Services.AddScoped<UsuariosInterface, UsuariosRepositorio>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint(url: "swagger/v1/swagger.json", name: "v1");
        options.RoutePrefix = String.Empty;
    });
}

app.UseHttpsRedirection();

app.UseCors(x => x.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

app.UseAuthorization();

app.MapControllers();

app.Run();
