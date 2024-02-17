using _404_game_portal.backend.Dto;
using _404_game_portal.backend.Entities;
using _404_game_portal.backend.Extensions;
using _404_game_portal.backend.Models;
using _404_game_portal.backend.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace _404_game_portal.backend.Repositories;

public interface IGameRepository
{
    public GameDto GetById(Guid id);

    public GameDto Create(GameCreationViewModel game);
    public List<GameDto> GetAll(GameFilterOptions filterOptions);
    List<GameDto> GetByIds(List<Guid> gameIds, bool includeAll = false);
}

public class GameRepository : IGameRepository
{
    private readonly Context _context;

    public GameRepository(Context context)
    {
        _context = context;
    }

    public GameDto GetById(Guid id)
    {
        return _context.Games
            .Include(e => e.GamePlatforms).ThenInclude(gp => gp.Platform)
            .Include(e => e.GameFeatures).ThenInclude(gf => gf.Feature)
            .Include(e => e.GameLanguages).ThenInclude(gl => gl.Language)
            .ToDto()
            .SingleOrDefault(e => e.Id == id) ?? new GameDto();
    }

    public GameDto Create(GameCreationViewModel creationViewModel)
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

    public List<GameDto> GetAll(GameFilterOptions filterOptions)
    {
        return _context.Games
                .Include(e => e.GamePlatforms).ThenInclude(gp => gp.Platform)
                .Include(e => e.GameFeatures).ThenInclude(gf => gf.Feature)
                .Include(e => e.GameLanguages).ThenInclude(gl => gl.Language)
                .WhereIf(!string.IsNullOrEmpty(filterOptions.GameName), e => e.Name.Contains(filterOptions.GameName!))
                .WhereIf(filterOptions.MaximumPrice.HasValue, e => e.GamePlatforms.Any(gp => gp.Price <= filterOptions.MaximumPrice))
                .WhereIf(filterOptions.PlatformId.HasValue, e => e.GamePlatforms.Any(gp => gp.PlatformId == filterOptions.PlatformId))
                .WhereIf(filterOptions.FeatureId.HasValue, e => e.GameFeatures.Any(gf => gf.FeatureId == filterOptions.FeatureId))
                .WhereIf(filterOptions.LanguageId.HasValue, e => e.GameLanguages.Any(gl => gl.LanguageId == filterOptions.LanguageId))
                .WhereIf(filterOptions.Usk.HasValue, e => e.USK == filterOptions.Usk)
                .ToDto()
                .ToList();
    }

    public List<GameDto> GetByIds(List<Guid> gameIds, bool includeAll = false)
    {
        return _context.Games
            .IncludeIf(includeAll, e => e.GamePlatforms)
            .IncludeIf(includeAll, e => e.GameFeatures)
            .IncludeIf(includeAll, e => e.GameLanguages)
            .Where(e => gameIds.Contains(e.Id))
            .ToDto()
            .ToList();
    }
}