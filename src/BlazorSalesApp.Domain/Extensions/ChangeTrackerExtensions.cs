using BlazorSalesApp.Domain.Models.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BlazorSalesApp.Domain.Extensions;

public static class ChangeTrackerExtensions
{
    public static void SetAuditProperties(this ChangeTracker changeTracker)
    {
        var entityEntries =
            changeTracker.Entries()
                .Where(entry => entry.Entity is BaseEntity &&
                            entry.State is EntityState.Deleted or EntityState.Added or EntityState.Modified);

        if (!entityEntries.Any())
        {
            return;
        }

        var timestamp = DateTime.UtcNow;

        foreach (var entry in entityEntries)
        {
            var entity = (BaseEntity) entry.Entity;

            if (entry.State == EntityState.Added)
            {
                entity.CreatedUtc = timestamp;
            }
            else if (entry.State == EntityState.Modified)
            {
                entity.UpdatedUtc = timestamp;
                entry.Property(nameof(BaseEntity.CreatedUtc)).IsModified = false;
            }
            else if (entry.State == EntityState.Deleted)
            {
                entity.DeletedUtc = timestamp;
                entry.Property(nameof(BaseEntity.CreatedUtc)).IsModified = false;
                entry.Property(nameof(BaseEntity.UpdatedUtc)).IsModified = false;
            }
        }
    }
}