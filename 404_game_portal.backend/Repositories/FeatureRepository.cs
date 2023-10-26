using _404_game_portal.backend.Entities;

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
        throw new NotImplementedException();
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