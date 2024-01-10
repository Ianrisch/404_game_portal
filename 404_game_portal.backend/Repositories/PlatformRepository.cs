using _404_game_portal.backend.Entities;
using _404_game_portal.backend.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace _404_game_portal.backend.Repositories;

public interface IPlatformRepository
{
    public Platform GetById(Guid id);
    public Platform Create(PlatformCreationViewModel platform);
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
            .Include(e => e.GamePlatforms)
            .SingleOrDefault(e => e.Id == id) ?? new Platform();
    }

    public Platform Create(PlatformCreationViewModel creationViewModel)
    {
        var platform = new Platform
        {
            PlatformName = creationViewModel.PlatformName,
            PlatformVersion = creationViewModel.PlatformVersion,
            PlatformType = creationViewModel.PlatformType,
            GamePlatforms = creationViewModel.GamesAndPrices.Select(priceAndPlatformViewModel => new GamePlatform
            {
                GameId = priceAndPlatformViewModel.GameId,
                Price = priceAndPlatformViewModel.Price
            }).ToList()
        };

        _context.Platforms.Add(platform);
        _context.SaveChanges();
        return platform;
    }

    public List<Platform> GetAll()
    {
        return _context.Platforms
            .Include(e => e.GamePlatforms)
            .ToList();
    }
}