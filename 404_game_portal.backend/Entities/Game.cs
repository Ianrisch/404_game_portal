namespace _404_game_portal.backend.Entities;

public class Game
{
    public string Name { get; set; }
    public List<Platform> Platforms { get; set; }
    public USK USK { get; set; }
    public double Price { get; set; }
    public DateOnly ReleaseDate { get; set; }
    public string Description { get; set; }
    public List<Feature> Features { get; set; }
    public List<Language> Languages { get; set; }
}