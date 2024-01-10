using AutoMapper;

namespace BlazorSalesApp.Application.Tests;

public class MapperProfilesTests
{
    [Fact]
    public void AssertConfigurationIsValid()
    {
        var currentDomainAssemblies = AppDomain.CurrentDomain.GetAssemblies();
        var config = new MapperConfiguration(configuration =>
        {
            configuration.AddMaps(typeof(ApplicationModule).Assembly);
        });

        config.AssertConfigurationIsValid();
    }
}