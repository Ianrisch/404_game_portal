using _404_game_portal.backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace _404_game_portal.backend.Repositories;

public interface IGameRepository
{
    public Game GetById(Guid id);
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
        throw new NotImplementedException();
    }
}