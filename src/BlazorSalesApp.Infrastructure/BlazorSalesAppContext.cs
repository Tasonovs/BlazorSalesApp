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
        SeedInitialData(modelBuilder);
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

    private static void SeedInitialData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>()
            .HasData(new List<Order>
            {
                new()
                {
                    Id = 1,
                    Name = "New York Building 1",
                    StateId = 1,
                },
                new()
                {
                    Id = 2,
                    Name = "California Hotel AJK",
                    StateId = 2,
                },
            });

        modelBuilder.Entity<Window>()
            .HasData(new List<Window>
            {
                new()
                {
                    Id = 1,
                    OrderId = 1,
                    Name = "A51",
                    QuantityOfWindows = 4,
                },
                new()
                {
                    Id = 2,
                    OrderId = 1,
                    Name = "C Zone 5",
                    QuantityOfWindows = 2,
                },
                new()
                {
                    Id = 3,
                    OrderId = 2,
                    Name = "GLB",
                    QuantityOfWindows = 3,
                },
                new()
                {
                    Id = 4,
                    OrderId = 2,
                    Name = "OHF",
                    QuantityOfWindows = 10,
                },
            });

        modelBuilder.Entity<SubElement>()
            .HasData(new List<SubElement>()
            {
                new()
                {
                    Id = 1,
                    WindowId = 1,
                    TypeId = 2,
                    Width = 1200,
                    Height = 1850,
                },
                new()
                {
                    Id = 2,
                    WindowId = 1,
                    TypeId = 1,
                    Width = 800,
                    Height = 1850,
                },
                new()
                {
                    Id = 3,
                    WindowId = 1,
                    TypeId = 1,
                    Width = 700,
                    Height = 1850,
                },
                new()
                {
                    Id = 4,
                    WindowId = 2,
                    TypeId = 1,
                    Width = 1500,
                    Height = 2000,
                },
                new()
                {
                    Id = 5,
                    WindowId = 3,
                    TypeId = 2,
                    Width = 1400,
                    Height = 2200,
                },
                new()
                {
                    Id = 6,
                    WindowId = 3,
                    TypeId = 1,
                    Width = 600,
                    Height = 2200,
                },
                new()
                {
                    Id = 7,
                    WindowId = 4,
                    TypeId = 1,
                    Width = 1500,
                    Height = 2000,
                },
                new()
                {
                    Id = 8,
                    WindowId = 4,
                    TypeId = 1,
                    Width = 1500,
                    Height = 2000,
                },
            });
    }
}