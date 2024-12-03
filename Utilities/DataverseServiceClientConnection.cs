using Microsoft.Crm.Sdk.Messages;
using Microsoft.PowerPlatform.Dataverse.Client;
using Microsoft.Extensions.Configuration;
using System;
using Microsoft.Xrm.Sdk;

namespace CognizantDataverse.Utilities
{
    public class DataverseServiceClientConnection
    {
        private readonly string _connectionString;

        public DataverseServiceClientConnection(IConfiguration configuration)
        {
            // Fetch environment variables
            var SecretId = configuration["Dataverse:SecretId"];
            var AppId = configuration["Dataverse:AppId"];
            var InstanceUri = configuration["Dataverse:InstanceUri"];

            var requiredVariables = new[] { SecretId, AppId, InstanceUri };
            if (requiredVariables.Any(string.IsNullOrEmpty))
            {
                throw new Exception("Environment variables for Dataverse connection are not properly configured.");
            }

            // This service connection string uses the info provided above.
            // // The AppId and RedirectUri are provided for sample code testing.
            _connectionString = $@"AuthType=ClientSecret;
                                    SkipDiscovery=true;
                                    Url={InstanceUri};
                                    Secret={SecretId};
                                    ClientId={AppId};
                                    RequireNewInstance=true";
        }
        
        public IOrganizationService Connect()
        {
            //ServiceClient implements IOrganizationService interface
            IOrganizationService service = new ServiceClient(_connectionString);
            return service;
        }

    }
}
