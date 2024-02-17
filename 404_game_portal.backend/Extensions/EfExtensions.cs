using System.Linq.Expressions;
using _404_game_portal.backend.Dto;
using _404_game_portal.backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace _404_game_portal.backend.Extensions;

public static class EfExtensions
{
    public static IQueryable<TEntity> IncludeIf<TEntity, TProperty>(
        this IQueryable<TEntity> queryable,
        bool shouldInclude,
        Expression<Func<TEntity, TProperty>> navigationPropertyPath)
        where TEntity : class
    {
        return shouldInclude ? queryable.Include(navigationPropertyPath) : queryable;
    }

    public static IQueryable<GameDto> ToDto(this IQueryable<Game> queryable)
    {
        return queryable.Select(g => new GameDto
        {
            Id = g.Id,
            Name = g.Name,
            GamePlatforms = g.GamePlatforms,
            USK = g.USK,
            ReleaseDate = g.ReleaseDate,
            Description = g.Description,
            GameFeatures = g.GameFeatures,
            GameLanguages = g.GameLanguages,
            RatingAverage = g.GameRatings.Count == 0 ? 0 : g.GameRatings.Average(gr => gr.Rating),
            TotalRatings = g.GameRatings.Count
        });
    }
}