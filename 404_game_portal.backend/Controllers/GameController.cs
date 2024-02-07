using _404_game_portal.backend.Attributes;
using _404_game_portal.backend.Enums;
using _404_game_portal.backend.Repositories;
using _404_game_portal.backend.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace _404_game_portal.backend.Controllers;
[ApiController]
[Route("api/[controller]")]
public class GameController : ControllerBase
{
    private readonly IGameRepository _gameRepository;

    public GameController(IGameRepository gameRepository)
    {
        _gameRepository = gameRepository;
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
}