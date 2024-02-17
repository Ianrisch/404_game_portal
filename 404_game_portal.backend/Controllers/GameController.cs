using _404_game_portal.backend.Attributes;
using _404_game_portal.backend.Enums;
using _404_game_portal.backend.Repositories;
using _404_game_portal.backend.Services;
using _404_game_portal.backend.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace _404_game_portal.backend.Controllers;
[ApiController]
[Route("api/[controller]")]
public class GameController : ControllerBase
{
    private readonly IGameRepository _gameRepository;
    private readonly IGameRatingRepository _gameRatingRepository;
    private readonly IUserRepository _userRepository;

    public GameController(IGameRepository gameRepository, IGameRatingRepository gameRatingRepository, IUserRepository userRepository)
    {
        _gameRepository = gameRepository;
        _gameRatingRepository = gameRatingRepository;
        _userRepository = userRepository;
    }

    [HttpGet]
    public List<GameViewModel> GetAll()
    {
        return _gameRepository.GetAll().Select(game => new GameViewModel(game)).ToList();
    }

    [HttpPost]
    [CustomAuthorize(Role.Admin)]
    public GameViewModel Create(GameCreationViewModel creationViewModel)
    {
        return new GameViewModel(_gameRepository.Create(creationViewModel));
    }

    [HttpGet("{id:guid}")]
    public GameViewModel GetById(Guid id)
    {
        return new GameViewModel(_gameRepository.GetById(id));
    }

    [HttpGet("rate")]
    [CustomAuthorize(Role.User)]
    public async Task<RatingViewModel> Rate([FromQuery]int rating, [FromQuery]Guid gameId)
    {
        var creationViewModel = new RatingCreationViewModel
        {
            Rating = rating,
            GameId = gameId,
            UserId = (await _userRepository.GetByMailOrUsername(User.Identity!.Name!))!.Id
        };
        return new RatingViewModel(_gameRatingRepository.UpdateOrCreate(creationViewModel));
    }
}