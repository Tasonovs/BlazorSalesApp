using Microsoft.EntityFrameworkCore;

namespace BlazorSalesApp.Application.Common.Extensions;

public static class DbContextExtensions
{
    public static void UpdateChildCollection<TId, TChild>(
        this DbContext dbContext,
        IEnumerable<TChild> dbItems,
        IEnumerable<TChild> newItems,
        Func<TChild, TId> idSelector) where TChild : class where TId : notnull
    {
        if (!dbItems.Any() && !newItems.Any())
        {
            return;
        }

        var original = dbItems
            .ToDictionary(idSelector);
        var updated = newItems
            .Where(child => !idSelector(child).Equals((TId) default!))
            .ToDictionary(idSelector);

        var toRemove = original
            .Where(pair => !updated.ContainsKey(pair.Key))
            .ToList();
        toRemove.ForEach(i =>
            dbContext.Set<TChild>().Remove(i.Value));

        var toUpdate = original
            .Where(i => updated.ContainsKey(i.Key))
            .ToList();
        toUpdate.ForEach(pair =>
            dbContext.Entry(pair.Value).CurrentValues.SetValues(updated[pair.Key]));

        var toAdd = newItems
            .Where(child => idSelector(child).Equals((TId) default!))
            .ToList();
        toAdd.ForEach(child =>
            dbContext.Set<TChild>().Add(child));
    }
}