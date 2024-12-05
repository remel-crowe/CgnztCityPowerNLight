
using CognizantDataverse.Utilities;
using CognizantDataverse.App;

namespace CognizantDataverse
{
    class Program
    {
        private static void Main(string[] args)
        {
            // Initialise DataverseServiceClientConnection with the configuration
            var dataverseConnection = DataverseServiceClientConnection.Connect(ConfigBuilder.BuildConfiguration());
            
            var app = new CustomerServiceHubApp(dataverseConnection);
            // Run the app
            try
            {
                app.Demo();
            } catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
          
        }
    }
}