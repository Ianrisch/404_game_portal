using _404_game_portal.backend.Attributes;
using _404_game_portal.backend.Enums;
using _404_game_portal.backend.Repositories;
using _404_game_portal.backend.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace _404_game_portal.backend.Controllers;

[ApiController]
[Route("api/[controller]")]
[CustomAuthorize(Role.User, Role.Admin)]
public class RatingController(IGameRatingRepository gameRatingRepository, IUserRepository userRepository)
    : ControllerBase
{
    [HttpPost]
    public async Task<RatingViewModel> Rate([FromQuery] double rating, [FromQuery] Guid gameId)
    {
        var creationViewModel = new RatingCreationViewModel
        {
            Rating = rating,
            GameId = gameId,
            UserId = (await userRepository.GetByMailOrUsername(User.Identity!.Name!))!.Id
        };
        return new RatingViewModel(gameRatingRepository.UpdateOrCreate(creationViewModel));
    }
    
    [HttpGet("{gameId:guid}")]
    public async Task<RatingViewModel> GetById(Guid gameId)
    {
        var gameRating = gameRatingRepository.GetById(gameId, (await userRepository.GetByMailOrUsername(User.Identity!.Name!))!.Id);
        return new RatingViewModel(gameRating);
    }
    
}