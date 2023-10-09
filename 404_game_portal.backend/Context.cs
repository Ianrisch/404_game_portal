using _404_game_portal.backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace _404_game_portal.backend;

public class Context : DbContext
{
    private readonly IConfiguration _configurationManager;

    public Context(IConfiguration configurationManager)
        : base()
    {
        _configurationManager = configurationManager;
    }

    private const string ConnectionString = "server=localhost;port=3306;database=GamePortal;user=root;password=root";

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql(_configurationManager.GetConnectionString("Database"), new MySqlServerVersion(new Version(10, 3, 18)));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Game>()
            .HasMany(g => g.Platforms)
            .WithMany(p => p.Games);
        modelBuilder.Entity<Game>()
            .HasMany(g => g.Languages)
            .WithMany(p => p.Games);
        modelBuilder.Entity<Game>()
            .HasMany(g => g.Features)
            .WithMany(p => p.Games);
        modelBuilder.Entity<Game>()
            .HasMany(g => g.Prices)
            .WithOne(p => p.Game);
        modelBuilder.Entity<PriceOnPlatform>()
            .HasOne(e => e.Platform)
            .WithMany(e => e.Prices)
            .HasForeignKey(e => e.PlatformId)
            .IsRequired();

    }

    public DbSet<Game> Games { get; set; }
    public DbSet<Platform> Platforms { get; set; }
    public DbSet<Language> Languages { get; set; }
    public DbSet<Feature> Features { get; set; }
    public DbSet<PriceOnPlatform> PricesOnPlatform { get; set; }
}