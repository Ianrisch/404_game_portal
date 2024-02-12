using _404_game_portal.backend.Entities;
using _404_game_portal.backend.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace _404_game_portal.backend.Repositories;

public interface IGameRatingRepository
{
    GameRating GetById(Guid gameId, Guid userId);
    GameRating UpdateOrCreate (RatingCreationViewModel creationViewModel);
}

public class GameRatingRepository : IGameRatingRepository
{
    private readonly Context _context;

    public GameRatingRepository(Context context)
    {
        _context = context;
    }
    
    public GameRating GetById(Guid gameId, Guid userId)
    {
        return _context.GameRatings
            .Include(gr => gr.User)
            .Include(gr => gr.Game)
            .SingleOrDefault(gr => gr.UserId == userId && gr.GameId == gameId) ?? new GameRating();
    }
    
    public GameRating UpdateOrCreate (RatingCreationViewModel creationViewModel)
    {
        var gameRating = new GameRating
        {
            UserId = creationViewModel.UserId,
            GameId = creationViewModel.GameId,
            Rating = creationViewModel.Rating
        };

        _context.GameRatings.Add(gameRating);
        _context.SaveChanges();
        return GetById(gameRating.GameId, gameRating.UserId);
    }
}