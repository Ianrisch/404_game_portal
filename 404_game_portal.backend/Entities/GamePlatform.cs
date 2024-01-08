namespace _404_game_portal.backend.Entities;

public class GamePlatform
{
    public Game Game { get; set; }
    public Guid GameId { get; set; }
    public Platform Platform { get; set; }
    public Guid PlatformId { get; set; }
    public double Price { get; set; }
}