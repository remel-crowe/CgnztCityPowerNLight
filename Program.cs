using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using CognizantDataverse.Utilities;
using CognizantDataverse.App;

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
            
            // Create a new instance of CustomerServiceHubAPI
            var app = new CustomerServiceHubAPI(dataverseConnection);
            
            // Run the app
            app.Demo();
          
        }
    }
}