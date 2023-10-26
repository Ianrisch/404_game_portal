using _404_game_portal.backend.Entities;
using _404_game_portal.backend.Repositories;
using _404_game_portal.backend.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace _404_game_portal.backend.Controllers;

[ApiController] 
[Route("[controller]")] 
public class GameController : ControllerBase
{
    private readonly IGameRepository _gameRepository;

    public GameController(IGameRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }

    [HttpPost]
    public Game Create(GameCreationViewModel creationViewModel)
    {
        var game = new Game
        {
            Name = creationViewModel.Name,
            Platforms = creationViewModel.Platforms,
            USK = creationViewModel.USK,
            Prices = creationViewModel.Prices,
            ReleaseDate = creationViewModel.ReleaseDate,
            Description = creationViewModel.Description,
            Features = creationViewModel.Features,
            Languages = creationViewModel.Languages
        };

        return _gameRepository.Create(game);
    }
}