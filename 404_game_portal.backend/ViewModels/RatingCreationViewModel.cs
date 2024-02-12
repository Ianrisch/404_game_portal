using _404_game_portal.backend.Entities;

namespace _404_game_portal.backend.ViewModels;

public class RatingCreationViewModel
{
    public Guid UserId { get; set; }
    public Guid GameId { get; set; }
    public int Rating { get; set; }
}