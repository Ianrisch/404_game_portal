using _404_game_portal.backend.Entities;

namespace _404_game_portal.backend.Dto;

public class GameDto
{
    public Guid Id { get; set; }

    public string Name { get; set; }
    public List<GamePlatform> GamePlatforms { get; set; }
    public Usk USK { get; set; }
    public DateOnly ReleaseDate { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public List<GameFeature> GameFeatures { get; set; }
    public List<GameLanguage> GameLanguages { get; set; }
    public double RatingAverage { get; set; }
    public int TotalRatings { get; set; }
    
}