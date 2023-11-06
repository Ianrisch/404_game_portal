using _404_game_portal.backend.Entities;
using _404_game_portal.backend.Repositories;
using _404_game_portal.backend.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace _404_game_portal.backend.Controllers;

[Controller, Route("[controller]")]
public class PricesOnPlatformController : ControllerBase
{
    private readonly IPriceOnPlatformRepository _priceOnPlatformRepository;
    private readonly IGameRepository _gameRepository;
    private readonly IPlatformRepository _platformRepository;

    public PricesOnPlatformController(IPriceOnPlatformRepository priceOnPlatformRepository,
        IGameRepository gameRepository,
        IPlatformRepository platformRepository)
    {
        _priceOnPlatformRepository = priceOnPlatformRepository;
        _gameRepository = gameRepository;
        _platformRepository = platformRepository;
    }

    [HttpGet("{id:guid}")]
    public PriceOnPlatformViewModel GetById(Guid id)
    {
        var priceOnPlatform = _priceOnPlatformRepository.GetById(id);
        var priceOnPlatformViewModel = new PriceOnPlatformViewModel(priceOnPlatform);
        return priceOnPlatformViewModel;
    }

    [HttpGet]
    public List<PriceOnPlatformViewModel> GetAll()
    {
        var pricesOnPlatform = _priceOnPlatformRepository.GetAll();
        var pricesOnPlatformViewModels = pricesOnPlatform
            .Select(priceOnPlatform => new PriceOnPlatformViewModel(priceOnPlatform)).ToList();
        return pricesOnPlatformViewModels;
    }

    [HttpPost]
    public PriceOnPlatformViewModel Create([FromBody] PriceOnPlatformCreationViewModel creationViewModel)
    {
        var game = _gameRepository.GetById(creationViewModel.Game);
        var platform = _platformRepository.GetById(creationViewModel.Platform);

        var priceOnPlatform =
            _priceOnPlatformRepository.Create(new PriceOnPlatform
            {
                Price = creationViewModel.Price,
                Game = game,
                Platform = platform
            });
        return new PriceOnPlatformViewModel(priceOnPlatform);
    }
}