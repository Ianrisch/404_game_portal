using _404_game_portal.backend.ViewModels;

namespace _404_game_portal.backend.Entities;

public class Game
{
    public Guid Id { get; set; }

    public string Name { get; set; }
    public List<Platform> Platforms { get; set; }
    public USK USK { get; set; }
    public List<PriceOnPlatform> Prices { get; set; }
    public DateOnly ReleaseDate { get; set; }
    public string Description { get; set; }
    public List<Feature> Features { get; set; }
    public List<Language> Languages { get; set; }

    public Game(GameCreationViewModel creationViewModel)
    {
        Name = creationViewModel.Name;
        Platforms = creationViewModel.Platforms.Select(platform => new Platform(platform)).ToList();
        USK = creationViewModel.USK;
        ReleaseDate = creationViewModel.ReleaseDate;
        Description = creationViewModel.Description;
        Features = creationViewModel.Features ?? new List<Feature>();
        Languages = creationViewModel.Languages.Select(language => new Language(language)).ToList();
    }

    public Game()
    {
    }
}