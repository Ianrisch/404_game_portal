using _404_game_portal.backend.Entities;
using _404_game_portal.backend.Extensions;
using _404_game_portal.backend.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace _404_game_portal.backend.Repositories;

public interface IGameRepository
{
    public Game GetById(Guid id);

    public Game Create(GameCreationViewModel game);
    public List<Game> GetAll();
    List<Game> GetByIds(List<Guid> gameIds, bool includeAll = false);
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
            .Include(e => e.GamePlatforms).ThenInclude(gp => gp.Platform)
            .Include(e => e.GameFeatures).ThenInclude(gf => gf.Feature)
            .Include(e => e.GameLanguages).ThenInclude(gl => gl.Language)
            .SingleOrDefault(e => e.Id == id) ?? new Game();
    }

    public Game Create(GameCreationViewModel creationViewModel)
    {
        var game = new Game(creationViewModel)
        {
            GamePlatforms = creationViewModel.Platforms.Select(priceAndPlatformViewModel => new GamePlatform
                {
                    PlatformId = priceAndPlatformViewModel.PlatformId,
                    Price = priceAndPlatformViewModel.Price
                })
                .ToList(),
            GameFeatures = creationViewModel.Features.Select(id => new GameFeature { FeatureId = id }).ToList(),
            GameLanguages = creationViewModel.Languages
                .Select(languageId => new GameLanguage { LanguageId = languageId }).ToList()
        };

        _context.Games.Add(game);
        _context.SaveChanges();
        
        return GetById(game.Id);
    }

    public List<Game> GetAll()
    {
        return _context.Games
            .Include(e => e.GamePlatforms).ThenInclude(gp => gp.Platform)
            .Include(e => e.GameFeatures).ThenInclude(gf => gf.Feature)
            .Include(e => e.GameLanguages).ThenInclude(gl => gl.Language)
            .ToList();
    }

    public List<Game> GetByIds(List<Guid> gameIds, bool includeAll = false)
    {
        return _context.Games
            .IncludeIf(includeAll, e => e.GamePlatforms)
            .IncludeIf(includeAll, e => e.GameFeatures)
            .IncludeIf(includeAll, e => e.GameLanguages)
            .Where(e => gameIds.Contains(e.Id))
            .ToList();
    }
}