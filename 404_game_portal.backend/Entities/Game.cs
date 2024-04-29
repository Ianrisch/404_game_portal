using _404_game_portal.backend.ViewModels;

namespace _404_game_portal.backend.Entities;

public class Game
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
    public List<GameRating> GameRatings { get; set; }
    public List<GameComment> GameComments { get; set; }

    public Game(GameCreationViewModel creationViewModel)
    {
        Name = creationViewModel.Name;
        USK = creationViewModel.USK;
        ReleaseDate = creationViewModel.ReleaseDate;
        Description = creationViewModel.Description;
        Image = "";
    }

    public Game()
    {
    }
}