namespace _404_game_portal.backend.Entities;

public class GameLanguage
{
    public Game Game { get; set; }
    public Guid GameId { get; set; }
    public Language Language { get; set; }
    public Guid LanguageId { get; set; }
}