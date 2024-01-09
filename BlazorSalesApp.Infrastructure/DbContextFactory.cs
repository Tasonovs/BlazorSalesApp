using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace BlazorSalesApp.Infrastructure;

public class DbContextFactory : IDesignTimeDbContextFactory<BlazorSalesAppContext>
{
    public BlazorSalesAppContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.migration.json")
            .AddJsonFile("appsettings.migration.Development.json")
            .Build();

        var connectionString = configuration.GetConnectionString("DefaultConnection");

        var dbContextOptionsBuilder = new DbContextOptionsBuilder<BlazorSalesAppContext>();
        dbContextOptionsBuilder.UseSqlServer(
            connectionString,
            builder => builder.MigrationsAssembly(typeof(BlazorSalesAppContext).GetTypeInfo().Assembly.GetName().Name));
        return new BlazorSalesAppContext(dbContextOptionsBuilder.Options);
    }
}
