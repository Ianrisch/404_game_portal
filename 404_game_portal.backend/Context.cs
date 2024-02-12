using _404_game_portal.backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace _404_game_portal.backend;

public class Context : DbContext
{
    private readonly IConfiguration _configurationManager;

    public Context(IConfiguration configurationManager)
    {
        _configurationManager = configurationManager;
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = _configurationManager.GetConnectionString("Database");
        optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(10, 3, 18)));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<GamePlatform>()
            .HasKey(gp => new { gp.GameId, gp.PlatformId });
        modelBuilder.Entity<GamePlatform>()
            .HasOne(gp => gp.Game)
            .WithMany(g => g.GamePlatforms)
            .HasForeignKey(gp => gp.GameId);
        modelBuilder.Entity<GamePlatform>()
            .HasOne(gp => gp.Platform)
            .WithMany(f => f.GamePlatforms)
            .HasForeignKey(gp => gp.PlatformId);

        modelBuilder.Entity<GameFeature>()
            .HasKey(gf => new { gf.GameId, gf.FeatureId });
        modelBuilder.Entity<GameFeature>()
            .HasOne(gf => gf.Game)
            .WithMany(g => g.GameFeatures)
            .HasForeignKey(gf => gf.GameId);
        modelBuilder.Entity<GameFeature>()
            .HasOne(gf => gf.Feature)
            .WithMany(f => f.GameFeatures)
            .HasForeignKey(gf => gf.FeatureId);

        modelBuilder.Entity<GameLanguage>()
            .HasKey(gf => new { gf.GameId, gf.LanguageId });
        modelBuilder.Entity<GameLanguage>()
            .HasOne(gf => gf.Game)
            .WithMany(g => g.GameLanguages)
            .HasForeignKey(gf => gf.GameId);
        modelBuilder.Entity<GameLanguage>()
            .HasOne(gf => gf.Language)
            .WithMany(f => f.GameLanguages)
            .HasForeignKey(gf => gf.LanguageId);
        
        modelBuilder.Entity<GameRating>()
            .HasKey(gf => new { gf.GameId, gf.UserId });
        modelBuilder.Entity<GameRating>()
            .HasOne(gf => gf.Game)
            .WithMany(g => g.GameRatings)
            .HasForeignKey(gf => gf.GameId);
        modelBuilder.Entity<GameRating>()
            .HasOne(gf => gf.User)
            .WithMany(f => f.GameRatings)
            .HasForeignKey(gf => gf.UserId);

        modelBuilder.Entity<User>().HasIndex(u =>u.Email).IsUnique();
        modelBuilder.Entity<User>().HasIndex(u =>u.Username).IsUnique();
    }

    public DbSet<Game> Games { get; set; }
    public DbSet<Platform> Platforms { get; set; }
    public DbSet<Language> Languages { get; set; }
    public DbSet<Feature> Features { get; set; }
    public DbSet<GameFeature> GameFeatures { get; set; }
    public DbSet<GamePlatform> GamePlatforms { get; set; }
    public DbSet<GameLanguage> GameLanguages { get; set; }
    public DbSet<GameRating> GameRatings { get; set; }
    public DbSet<User> Users { get; set; }
}