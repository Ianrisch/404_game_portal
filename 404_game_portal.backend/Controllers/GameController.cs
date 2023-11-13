using _404_game_portal.backend.Entities;
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
    public List<Game> GetAll()
    {
        return _gameRepository.GetAll();
    }

    [HttpPost]
    public Game Create(GameCreationViewModel creationViewModel)
    {
        var game = new Game(creationViewModel);
        return _gameRepository.Create(game);
    }

    [HttpGet("{id:guid}")]
    public Game GetById(Guid id)
    {
        return _gameRepository.GetById(id);
    }
}