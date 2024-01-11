namespace _404_game_portal.backend.Entities;

public class GameLanguage
{
    public virtual Game Game { get; set; }
    public Guid GameId { get; set; }
    public virtual Language Language { get; set; }
    public Guid LanguageId { get; set; }
}