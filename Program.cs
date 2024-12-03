using System;
using System.IO;
using System.Threading.Tasks;
using CognizantDataverse.Model;
using Microsoft.Extensions.Configuration;
using CognizantDataverse.Services;
using CognizantDataverse.Utilities;

namespace CognizantDataverse
{
    class Program
    {
        static void Main(string[] args)
        {
            // Build configuration to load from appsettings.json (Environment variables)
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // Initialise DataverseServiceClientConnection with the configuration
            var dataverseConnection = DataverseServiceClientConnection.Connect(configuration);

            // Initialise Services with the Dataverse connection
            var accountService = new AccountService(dataverseConnection);
            var contactService = new ContactService(dataverseConnection);

            
            //Mocked creating a new account
            // GUID of the account to retrieve
            var account = new Account
            {
                Name = "Test Account",
                Telephone1 = "1234567890",
                EMailAddress1 = "fakeemail@mail.com"
                

            };

    
            // Retrieve the account by its GUID
            Guid created = new Guid("1c1232af-7bb1-ef11-b8e8-6045bdcf868c");
            
            accountService.DeleteAccount(created);
        }
    }
}