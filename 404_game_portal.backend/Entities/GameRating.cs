namespace _404_game_portal.backend.Entities;

public class GameRating
{
    public User User { get; set; }
    public Guid UserId { get; set; }
    public Game Game { get; set; }
    public Guid GameId { get; set; }
    public int Rating { get; set; }
}