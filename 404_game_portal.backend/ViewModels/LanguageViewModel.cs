namespace _404_game_portal.backend.ViewModels;

public class LanguageViewModel
{
    public Guid Id  { get; set; }

    public List<GameViewModel> Games { get; set; }

    public string LanguageName { get; set; }
}