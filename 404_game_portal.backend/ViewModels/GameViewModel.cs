using _404_game_portal.backend.Dto;
using _404_game_portal.backend.Entities;

namespace _404_game_portal.backend.ViewModels;

public class GameViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<PlatformAndPriceViewModel> PlatformAndPrices { get; set; }
    public Usk USK { get; set; }
    public DateOnly ReleaseDate { get; set; }
    public string Description { get; set; }
    public List<FeatureViewModel> Features { get; set; }
    public List<LanguageViewModel> Languages { get; set; }
    public double RatingAverage { get; set; }
    public int TotalRatings { get; set; }


    public GameViewModel(GameDto game)
    {
        Id = game.Id;
        Name = game.Name;
        USK = game.USK;
        ReleaseDate = game.ReleaseDate;
        Description = game.Description;
        Features = game.GameFeatures.Select(gf => new FeatureViewModel(gf.Feature)).ToList();
        Languages = game.GameLanguages.Select(gl => new LanguageViewModel(gl.Language)).ToList();
        PlatformAndPrices = game.GamePlatforms.Select(gp => new PlatformAndPriceViewModel(gp)).ToList();
        RatingAverage = game.RatingAverage;
        TotalRatings = game.TotalRatings;
    }

    public GameViewModel()
    {
    }
}