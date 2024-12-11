using Microsoft.Extensions.Configuration;
namespace CognizantDataverse.Utilities;

public static class ConfigBuilder
{
    public static IConfiguration BuildConfiguration()
    {
        return new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();
    }
    
}