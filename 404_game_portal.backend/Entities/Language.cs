using _404_game_portal.backend.ViewModels;

namespace _404_game_portal.backend.Entities;

public class Language
{
    public Guid Id  { get; set; }

    public List<Game> Games { get; set; }
    public string LanguageName { get; set; }

    public Language(LanguageViewModel languageViewModel)
    {
        if (languageViewModel.Id is not null)
            Id = (Guid)languageViewModel.Id;

        LanguageName = languageViewModel.LanguageName;
    }

    public Language(LanguageCreationViewModel creationViewModel)
    {
        if (creationViewModel.Games is not null)
            Games = creationViewModel.Games;
        LanguageName = creationViewModel.LanguageName;

    }

    public Language()
    {
    }
}