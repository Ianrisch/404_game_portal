using _404_game_portal.backend.Entities;

namespace _404_game_portal.backend.ViewModels;

public class RatingViewModel
{
    public Guid UserId { get; set; }
    public Guid GameId { get; set; }
    public double Rating { get; set; }
    
    public RatingViewModel(GameRating gameRating)
    {
        UserId = gameRating.UserId;
        GameId = gameRating.GameId;
        Rating = gameRating.Rating;

    }
}