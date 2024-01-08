using _404_game_portal.backend.Entities;

namespace _404_game_portal.backend.ViewModels;

public class GameViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<PlatformViewModel> Platforms { get; set; }
    public Usk USK { get; set; }
    public DateOnly ReleaseDate { get; set; }
    public string Description { get; set; }
    public List<Feature> Features { get; set; }
    public List<Language> Languages { get; set; }

    public GameViewModel(Game game)
    {
        var platformViewModels = game.GamePlatforms.Select(platform => new PlatformViewModel(platform.Platform)).ToList();
        Id = game.Id;
        Name = game.Name;
        Platforms = platformViewModels;
        USK = game.USK;
        ReleaseDate = game.ReleaseDate;
        Description = game.Description;
        Features = game.GameFeatures.Select(gf => gf.Feature).ToList();
        Languages = game.GameLanguages.Select(gl => gl.Language).ToList();
    }

    public GameViewModel()
    {
    }
}