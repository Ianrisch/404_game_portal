﻿using _404_game_portal.backend.Repositories;

namespace _404_game_portal.backend;

public class Startup
{
    private IServiceCollection _services { get; set; }

    public Startup(IServiceCollection services)
    {
        _services = services;
    }

    public void Execute()
    {
        AddServices();
    }
    
    private void AddServices()
    {
        _services.AddControllers();
        _services.AddEndpointsApiExplorer();
        _services.AddSwaggerGen();
        AddCustomDbContext();
        AddCustomCors();
    }

    private void AddCustomDbContext()
    {
        _services.AddDbContext<Context>(dbContextOptions => dbContextOptions
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors());
    }

    private void AddCustomCors()
    {
        _services.AddCors(options =>
        {
            options.AddPolicy(name: "MyAllowSpecificOrigins",
                corsPolicyBuilder => { corsPolicyBuilder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();  });
        });  
    }

    private void AddRepositories()
    {
        _services.AddScoped<IGameRepository, GameRepository>();
    }
}