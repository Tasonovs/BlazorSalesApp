using System.Reflection;
using BlazorSalesApp.Domain.Extensions;
using BlazorSalesApp.Domain.Models.Common;
using BlazorSalesApp.Domain.Models.Orders;
using BlazorSalesApp.Domain.Models.SubElements;
using BlazorSalesApp.Domain.Models.Windows;
using Microsoft.EntityFrameworkCore;

namespace BlazorSalesApp.Infrastructure;

public class BlazorSalesAppContext : DbContext
{
    public DbSet<Order> Orders { get; set; }
    public DbSet<Window> Windows { get; set; }
    public DbSet<SubElement> SubElements { get; set; }

    public BlazorSalesAppContext(DbContextOptions<BlazorSalesAppContext> options)
        : base(options)
    {
    }

    public override int SaveChanges()
    {
        return base.SaveChangesAsync(CancellationToken.None).GetAwaiter().GetResult();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        ChangeTracker.DetectChanges();

        ChangeTracker.SetAuditProperties();

        return await base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var defaultSchemaNameForDatabase = "dbo";
        modelBuilder.HasDefaultSchema(defaultSchemaNameForDatabase);
        base.OnModelCreating(modelBuilder);

        ChangeEntitiesDeleteBehaviorToRestrict(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        SeedLookups(modelBuilder);
    }

    private static void ChangeEntitiesDeleteBehaviorToRestrict(ModelBuilder modelBuilder)
    {
        var cascadeForeignKeys = modelBuilder.Model.GetEntityTypes()
            .Where(it =>
                Type.GetType(it.Name)?.BaseType?.Name is nameof(BaseEntity) or nameof(BaseLookupEntity))
            .SelectMany(t => t.GetForeignKeys())
            .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

        foreach (var foreignKey in cascadeForeignKeys)
        {
            foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }

    private static void SeedLookups(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrderStateLookup>()
            .HasData(new List<OrderStateLookup>
            {
                new()
                {
                    Id = 1,
                    Label = "NY",
                },
                new()
                {
                    Id = 2,
                    Label = "CA",
                },
            });

        modelBuilder.Entity<SubElementTypeLookup>()
            .HasData(new List<SubElementTypeLookup>
            {
                new()
                {
                    Id = 1,
                    Label = "Window",
                },
                new()
                {
                    Id = 2,
                    Label = "Doors",
                },
            });
    }
}