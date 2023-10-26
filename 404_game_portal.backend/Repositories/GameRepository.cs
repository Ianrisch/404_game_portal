using _404_game_portal.backend.Entities;
using _404_game_portal.backend.Extensions;
using Microsoft.EntityFrameworkCore;

namespace _404_game_portal.backend.Repositories;

public interface IGameRepository
{
    public Game GetById(Guid id);

    public Game Create(Game game);
    public List<Game> GetAll();
    List<Game> GetByIds(List<Guid> games, bool includeAll = false);
}

public class GameRepository : IGameRepository
{
    private readonly Context _context;

    public GameRepository(Context context)
    {
        _context = context;
    }

    public Game GetById(Guid id)
    {
        return _context.Games
            .Include(e => e.Platforms)
            .Include(e => e.Prices)
            .Include(e => e.Features)
            .Include(e => e.Languages)
            .SingleOrDefault(e => e.Id == id) ?? new Game();
    }

    public Game Create(Game game)
    {
        _context.Games.Add(game);
        _context.SaveChanges();
        return game;
    }

    public List<Game> GetAll()
    {
        return _context.Games
            .Include(e => e.Platforms)
            .Include(e => e.Prices)
            .Include(e => e.Features)
            .Include(e => e.Languages)
            .ToList();
    }

    public List<Game> GetByIds(List<Guid> games, bool includeAll = false)
    {
        return _context.Games
            .IncludeIf(includeAll,e => e.Platforms)
            .IncludeIf(includeAll,e => e.Prices)
            .IncludeIf(includeAll,e => e.Features)
            .IncludeIf(includeAll,e => e.Languages)
            .Where(e => games.Contains(e.Id)).ToList();
    }
}