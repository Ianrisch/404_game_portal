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

    public PlatformController(IPlatformRepository platformRepository)
    {
        _platformRepository = platformRepository;
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
        return _platformRepository.Create(creationViewModel);
    }
}