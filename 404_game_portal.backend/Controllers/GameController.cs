using _404_game_portal.backend.Attributes;
using _404_game_portal.backend.Enums;
using _404_game_portal.backend.Models;
using _404_game_portal.backend.Repositories;
using _404_game_portal.backend.Services;
using _404_game_portal.backend.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace _404_game_portal.backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GameController(IGameRepository gameRepository, IFirebaseService firebaseService) : ControllerBase
{
    [HttpGet]
    public List<GameViewModel> GetAll([FromQuery] GameFilterOptions filterOptions)
    {
        return gameRepository.GetAll(filterOptions)
            .Select(game => new GameViewModel(game))
            .ToList();
    }

    [HttpPost]
    [CustomAuthorize(Role.Admin)]
    public async Task<ActionResult<GameViewModel>> Create([FromForm] GameCreationForm creationForm)
    {
        var gameCreationViewModel = JsonSerializer.Deserialize<GameCreationViewModel>(creationForm.GameCreationData);

        if (string.IsNullOrWhiteSpace(creationForm.GameCreationData) || gameCreationViewModel == null)
            return BadRequest("GameCreationViewModel is missing");

        var game = gameRepository.Create(gameCreationViewModel);

        var imagePath = await firebaseService.UploadImage("game", game.Id.ToString(), creationForm.Image);

        game = await gameRepository.UpdateGameImage(game.Id, imagePath);

        return new GameViewModel(game);
    }

    [HttpGet("{id:guid}")]
    public GameViewModel GetById(Guid id)
    {
        return new GameViewModel(gameRepository.GetById(id));
    }
}