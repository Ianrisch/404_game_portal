using _404_game_portal.backend.Entities;

namespace _404_game_portal.backend.ViewModels;

public class LanguageViewModel
{
    public LanguageViewModel(Language language)
    {
        Id = language.Id;
        LanguageName = language.LanguageName;
    }

    public Guid Id { get; set; }

    public List<GameViewModel> Games { get; set; }

    public string LanguageName { get; set; }
}