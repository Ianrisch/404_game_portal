using _404_game_portal.backend.Entities;
using _404_game_portal.backend.Repositories;
using _404_game_portal.backend.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace _404_game_portal.backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FeatureController : ControllerBase
{
    private readonly IFeatureRepository _featureRepository;
    private readonly IGameRepository _gameRepository;


    public FeatureController(IFeatureRepository featureRepository, IGameRepository gameRepository)
    {
        _featureRepository = featureRepository;
        _gameRepository = gameRepository;
    }

    [HttpGet]
    public List<Feature> GetAll()
    {
        return _featureRepository.GetAll();
    }

    [HttpGet("{id:guid}")]
    public Feature GetById(Guid id)
    {
        return _featureRepository.GetById(id);
    }

    [HttpPost]
    public Feature Create(FeatureCreationViewModel creationViewModel)
    {
        var feature = new Feature();
        feature.Games = _gameRepository.GetByIds(creationViewModel.Games);
        feature.FeatureName = creationViewModel.FeatureName;
        feature.FeatureDescription = creationViewModel.FeatureDescription;
        return _featureRepository.Create(feature);
    }
}