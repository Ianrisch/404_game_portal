using _404_game_portal.backend.Entities;
using _404_game_portal.backend.Repositories;
using _404_game_portal.backend.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace _404_game_portal.backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlatformController : ControllerBase
{
    private readonly IPlatformRepository _platformRepository;
    private readonly IGameRepository _gameRepository;

    public PlatformController(IPlatformRepository platformRepository, IGameRepository gameRepository)
    {
        _platformRepository = platformRepository;
        _gameRepository = gameRepository;
    }

    [HttpGet]
    public List<Platform> GetAll()
    {
        return _platformRepository.GetAll();
    }

    [HttpGet("{id:guid}")]
    public Platform GetById(Guid id)
    {
        return _platformRepository.GetById(id);
    }

    [HttpPost]
    public Platform Create(PlatformCreationViewModel creationViewModel)
    {
        var platform = new Platform
        {
            GamePlatforms = creationViewModel.Games.Select(id => new GamePlatform { GameId = id }).ToList(),
            PlatformName = creationViewModel.PlatformName,
            PlatformVersion = creationViewModel.PlatformVersion,
            PlatformType = creationViewModel.PlatformType
        };
        return _platformRepository.Create(platform);
    }
}