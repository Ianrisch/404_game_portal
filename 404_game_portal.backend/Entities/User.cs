using _404_game_portal.backend.Enums;

namespace _404_game_portal.backend.Entities;

public class User
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public Role Role { get; set; }
    public List<GameRating> GameRatings { get; set; }
    public List<GameComment> GameComments { get; set; }
}