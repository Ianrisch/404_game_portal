using _404_game_portal.backend.Entities;

namespace _404_game_portal.backend.ViewModels;

public class GameViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<PlatformViewModel> Platforms { get; set; }
    public USK USK { get; set; }
    public List<PriceOnPlatform> Prices { get; set; }
    public DateOnly ReleaseDate { get; set; }
    public string Description { get; set; }
    public List<Feature> Features { get; set; }
    public List<Language> Languages { get; set; }

    public GameViewModel(Game game)
    {
        var platformViewModels = game.Platforms.Select(platform => new PlatformViewModel(platform)).ToList();
        Id = game.Id;
        Name = game.Name;
        Platforms = platformViewModels;
        USK = game.USK;
        Prices = game.Prices;
        ReleaseDate = game.ReleaseDate;
        Description = game.Description;
        Features = game.Features;
        Languages = game.Languages;
    }

    public GameViewModel()
    {
    }
}