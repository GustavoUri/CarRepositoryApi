using CarAPI.Data.DbEFContext;
using CarAPI.Data.Interfaces;
using CarAPI.Data.Repositories;
using CarAPI.Domain.Entities;
using CarAPI.Services.Interfaces;
using CarAPI.Services.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace CarDirectoryAPI;

public static class ServiceExtensions
{
    public static void ConfigureDatabase(this IServiceCollection services)
    {
        services.AddDbContext<EFDbContext>(options =>
            options.UseSqlite("Data Source=db2.db"));
    }
    public static void ConfigureSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1.0",
                Title = "CarDirectoryAPI",
                Description = "An Api for finding and adding cars",
                Contact = new OpenApiContact
                {
                    Name = "Ural Aminev",
                    Email = "aminevural50@gmail.com"
                },
            });
            const string xmlPath = @"CarDirectoryAPI.xml";
            options.IncludeXmlComments(xmlPath);
        });
    }
    
    public static void ConfigureEmbeddedServices(this IServiceCollection services)
    {
        services.AddCors();
        services.AddControllers();
        services.AddEndpointsApiExplorer();
    }
    
    public static void ConfigureCustomServices(this IServiceCollection services)
    {
        services.AddScoped<IRepository<Car>, CarRepository>();
        services.AddScoped<ICarService, CarService>();
        services.AddScoped<IStatisticsService, StatisticsService>();
    }
}