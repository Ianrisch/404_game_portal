using _404_game_portal.backend.Repositories;

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
        AddCustomDbContext();
        AddCustomCors();
        AddRepositories();
        AddServices();
    }

    private void AddServices()
    {
        _services.AddControllers().AddNewtonsoftJson(x =>
            x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        _services.AddEndpointsApiExplorer();
        _services.AddSwaggerGen();
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
                corsPolicyBuilder => { corsPolicyBuilder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod(); });
        });
    }

    private void AddRepositories()
    {
        _services.AddScoped<IGameRepository, GameRepository>();
        _services.AddScoped<ILanguageRepository, LanguageRepository>();
        _services.AddScoped<IFeatureRepository, FeatureRepository>();
        _services.AddScoped<IPlatformRepository, PlatformRepository>();
    }
}