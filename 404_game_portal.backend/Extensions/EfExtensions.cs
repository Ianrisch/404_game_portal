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
    public static IQueryable<TEntity> WhereIf<TEntity>(
        this IQueryable<TEntity> queryable,
        bool shouldInclude,
        Expression<Func<TEntity,bool>> predicate)
    {
        return shouldInclude ? queryable.Where(predicate) : queryable;
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
            Image = g.Image,
            GameFeatures = g.GameFeatures,
            GameLanguages = g.GameLanguages,
            RatingAverage = g.GameRatings.Count == 0 ? 0 : g.GameRatings.Average(gr => gr.Rating),
            TotalRatings = g.GameRatings.Count
        });
    }
    
    public static IQueryable<GameCommentDto> ToDto(this IQueryable<GameComment> queryable)
    {
        return queryable.Select(gc => new GameCommentDto
        {
            Id = gc.Id,
            GameId = gc.GameId,
            Comment = gc.Comment,
            UserDto = new GameCommentUserDto()
            {
                Id = gc.User.Id,
                Username = gc.User.Username
            }
        });
    }
}