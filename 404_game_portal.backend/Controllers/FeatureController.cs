using _404_game_portal.backend.Entities;
using _404_game_portal.backend.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace _404_game_portal.backend.Controllers;

[ApiController]
[Route("[controller]")]
public class FeatureController : ControllerBase
{
    private readonly IFeatureRepository _featureRepository;

    public FeatureController(IFeatureRepository featureRepository)
    {
        _featureRepository = featureRepository;
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
    public Feature Create()
    {
        
    }
}