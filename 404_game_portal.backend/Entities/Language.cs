using _404_game_portal.backend.ViewModels;

namespace _404_game_portal.backend.Entities;

public class Language
{
    public Guid Id { get; set; }

    public List<GameLanguage> GameLanguages { get; set; }
    public string LanguageName { get; set; }

    public Language(LanguageViewModel languageViewModel)
    {
        Id = languageViewModel.Id;
        LanguageName = languageViewModel.LanguageName;
    }

    public Language()
    {
    }
}