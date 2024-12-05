using Microsoft.PowerPlatform.Dataverse.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Xrm.Sdk;

namespace CognizantDataverse.Utilities
{
    public static class DataverseServiceClientConnection
    {
        private static string? _connectionString;

        /// <summary>
        /// Connects to the Dataverse environment using the provided configuration.
        /// </summary>
        /// <param name="configuration">The configuration which contains read access to environment variables.</param>
        /// <returns>An instance of IOrganizationService connected to the Dataverse environment.</returns>
        public static IOrganizationService Connect(IConfiguration configuration)
        {
            // Fetch environment variables from the configuration
            var secretId = configuration["Dataverse:SecretId"];
            var appId = configuration["Dataverse:AppId"];
            var instanceUri = configuration["Dataverse:InstanceUri"];

            // Check if any required variables are missing
            var requiredVariables = new[] { secretId, appId, instanceUri };
            if (requiredVariables.Any(string.IsNullOrEmpty))
            {
                throw new Exception("Environment variables for Dataverse connection are not properly configured.");
            }

            // Construct the connection string using the provided variables
            _connectionString = $@"AuthType=ClientSecret;
                                    SkipDiscovery=true;
                                    Url={instanceUri};
                                    Secret={secretId};
                                    ClientId={appId};
                                    RequireNewInstance=true";

            // Create a new ServiceClient instance using the connection string
            var service = new ServiceClient(_connectionString);
            return service;
        }
    }
}