namespace _404_game_portal.backend.Entities;

public class Language
{
    public Guid Id  { get; set; }

    public List<Game> Games { get; set; }
    public string LanguageName { get; set; }
}