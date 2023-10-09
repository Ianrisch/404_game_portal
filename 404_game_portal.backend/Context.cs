using _404_game_portal.backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace _404_game_portal.backend;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options)
        : base(options)
    {
    }

    private const string ConnectionString = "server=localhost;port=3306;database=GamePortal;user=root;password=root";

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql(ConnectionString, new MySqlServerVersion(new Version(10, 3, 18)));
    }

    public DbSet<Game> Games { get; set; }
    public DbSet<Platform> Platforms { get; set; }
    public DbSet<Language> Languages { get; set; }
    public DbSet<Feature> Features { get; set; }
    public DbSet<PriceOnPlatform> PricesOnPlatform { get; set; }
}