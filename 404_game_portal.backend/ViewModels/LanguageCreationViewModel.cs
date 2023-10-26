using _404_game_portal.backend.Entities;

namespace _404_game_portal.backend.ViewModels;

public class LanguageCreationViewModel
{
    public List<Guid>? Games { get; set; }

    public string LanguageName { get; set; }
}