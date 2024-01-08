using _404_game_portal.backend.Entities;
using _404_game_portal.backend.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace _404_game_portal.backend.Repositories;

public interface IFeatureRepository
{
    public Feature GetById(Guid id);
    public Feature Create(FeatureCreationViewModel feature);
    public List<Feature> GetAll();
}

public class FeatureRepository : IFeatureRepository
{
    private readonly Context _context;

    public FeatureRepository(Context context)
    {
        _context = context;
    }

    public Feature GetById(Guid id)
    {
        return _context.Features
            .Include(e => e.GameFeatures)
            .SingleOrDefault(e => e.Id == id) ?? new Feature();
    }

    public Feature Create(FeatureCreationViewModel creationViewModel)
    {
        var feature = new Feature
        {
            FeatureName = creationViewModel.FeatureName,
            FeatureDescription = creationViewModel.FeatureDescription,
        };
        _context.Features.Add(feature);
        _context.SaveChanges();
        feature.GameFeatures = creationViewModel.Games.Select(id => new GameFeature { GameId = id }).ToList();
        _context.SaveChanges();
        return feature;
    }

    public List<Feature> GetAll()
    {
        return _context.Features.Include(e => e.GameFeatures).ToList();
    }
}