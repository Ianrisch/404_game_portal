using _404_game_portal.backend.Entities;

namespace _404_game_portal.backend.ViewModels;

public class GameCreationViewModel
{
    public string Name { get; set; }
    public List<PlatformViewModel> Platforms { get; set; }
    public USK USK { get; set; }
    public DateOnly ReleaseDate { get; set; }
    public string Description { get; set; }
    public List<Feature>? Features { get; set; }
    public List<LanguageViewModel> Languages { get; set; }
}