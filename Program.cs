using Api.Data;
using Api.Repositorios;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddEntityFrameworkSqlServer()
            .AddDbContext<Contexto>(
            options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))
            );

        builder.Services.AddScoped<IUsersRepositorio, UsersRepositorio>();
        builder.Services.AddScoped<ICuidadosRepositorio, CuidadosRepositorio>();
        builder.Services.AddScoped<ICatalogoRepositorio, CatalogoRepositorio>();
        builder.Services.AddScoped<IMinhasPlantasRepositorio, MinhasPlantasRepositorio>();
        builder.Services.AddScoped<IRelatorioRepositorio, RelatorioRepositorio>();

        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(
                policy =>
                {
                    policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
        });

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.UseCors();

        app.MapControllers();

        app.Run();
    }
}