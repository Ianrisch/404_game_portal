using _404_game_portal.backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace _404_game_portal.backend.Repositories;

public interface IPriceOnPlatformRepository
{
    public PriceOnPlatform GetById(Guid id);
    public PriceOnPlatform Create(PriceOnPlatform priceOnPlatform);
    public List<PriceOnPlatform> GetAll();
}


public class PriceOnPlatformRepository : IPriceOnPlatformRepository
{
    private readonly Context _context;

    public PriceOnPlatformRepository(Context context)
    {
        _context = context;
    }


    public PriceOnPlatform GetById(Guid id)
    {
        return _context.PricesOnPlatform
            .Include( p => p.Game)
            .Include( p => p.Platform)
            .FirstOrDefault(x => x.Id == id) ?? new PriceOnPlatform();
    }

    public PriceOnPlatform Create(PriceOnPlatform priceOnPlatform)
    {
        _context.PricesOnPlatform.Add(priceOnPlatform);
        _context.SaveChanges();
        return priceOnPlatform;
    }

    public List<PriceOnPlatform> GetAll()
    {
        return _context.PricesOnPlatform
            .Include( p => p.Game)
            .Include( p => p.Platform)
            .ToList();
    }
}