using System.Linq.Expressions;
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
}