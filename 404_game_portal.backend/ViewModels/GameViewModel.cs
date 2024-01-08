using _404_game_portal.backend.Entities;

namespace _404_game_portal.backend.ViewModels;

public class GameViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<PlatformAndPriceViewModel> Platforms { get; set; }
    public Usk USK { get; set; }
    public DateOnly ReleaseDate { get; set; }
    public string Description { get; set; }
    public List<FeatureViewModel> Features { get; set; }
    public List<LanguageViewModel> Languages { get; set; }

    public GameViewModel(Game game)
    {
        Id = game.Id;
        Name = game.Name;
        USK = game.USK;
        ReleaseDate = game.ReleaseDate;
        Description = game.Description;
        Features = game.GameFeatures.Select(gf => new FeatureViewModel(gf.Feature)).ToList();
        Languages = game.GameLanguages.Select(gl => new LanguageViewModel(gl.Language)).ToList();
        Platforms = game.GamePlatforms.Select(gp => new PlatformAndPriceViewModel(gp)).ToList();
    }

    public GameViewModel()
    {
    }
}