using _404_game_portal.backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace _404_game_portal.backend.Repositories;

public interface IPlatformRepository
{
    public Platform GetById(Guid id);
    public Platform Create(Platform platform);
    public List<Platform> GetAll();
}

public class PlatformRepository : IPlatformRepository
{
    private readonly Context _context;

    public PlatformRepository(Context context)
    {
        _context = context;
    }
    
    public Platform GetById(Guid id)
    {
        return _context.Platforms
            .Include(e => e.Games)
            .Include(e => e.Prices)
            .SingleOrDefault(e => e.Id == id) ?? new Platform();
    }

    public Platform Create(Platform platform)
    {
        _context.Platforms.Add(platform);
        _context.SaveChanges();
        return platform;
    }

    public List<Platform> GetAll()
    {
        return _context.Platforms
            .Include(e => e.Games)
            .Include(e => e.Prices)
            .ToList();

    }
}