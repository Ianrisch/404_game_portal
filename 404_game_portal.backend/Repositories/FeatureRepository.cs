using _404_game_portal.backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace _404_game_portal.backend.Repositories;

public interface IFeatureRepository
{
    public Feature GetById(Guid id);
    public Feature Create(Feature feature);
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
            .Include(e => e.Games)
            .SingleOrDefault(e => e.Id == id) ?? new Feature();
    }

    public Feature Create(Feature feature)
    {
        throw new NotImplementedException();
    }

    public List<Feature> GetAll()
    {
        throw new NotImplementedException();
    }
}