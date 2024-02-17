using _404_game_portal.backend.Attributes;
using _404_game_portal.backend.Enums;
using _404_game_portal.backend.Repositories;
using _404_game_portal.backend.Services;
using _404_game_portal.backend.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace _404_game_portal.backend.Controllers;
[ApiController]
[Route("api/[controller]")]
public class GameController(IGameRepository gameRepository) : ControllerBase
{
    [HttpGet]
    public List<GameViewModel> GetAll()
    {
        return gameRepository.GetAll().Select(game => new GameViewModel(game)).ToList();
    }

    [HttpPost]
    [CustomAuthorize(Role.Admin)]
    public GameViewModel Create(GameCreationViewModel creationViewModel)
    {
        return new GameViewModel(gameRepository.Create(creationViewModel));
    }

    [HttpGet("{id:guid}")]
    public GameViewModel GetById(Guid id)
    {
        return new GameViewModel(gameRepository.GetById(id));
    }
}