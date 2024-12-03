using System.IO;
using Microsoft.Extensions.Configuration;
using CognizantDataverse.Utilities;
using CognizantDataverse.Controllers;
using System.Net.Http.Headers;


namespace CognizantDataverse;

class Program
{
    static async Task Main(string[] args)
    {
        // Build configuration to load from appsettings.json (Environment variables)
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();
        
        // Initialise DataverseServiceClientConnection with the configuration
        var dataverseConnection = new DataverseServiceClientConnection(configuration);
        dataverseConnection.Connect();
        
        var accountController = new AccountController(configuration);
        
        // Create an account and print the result message
        // var createdAccount = await accountController.CreateAccount("John Doe", "jdeo@mail.com", "1234567890");
        
        
        //Get all accounts and print them
        var accounts = await accountController.GetAllAccounts();
        accounts.ForEach(account => account.Print());
        
        // Delete account and print the result message
        // var deleteMessage = await accountController.DeleteAccountById("ad82a4f2-b7b0-ef11-b8e8-6045bdcf868c");
        // Console.WriteLine(deleteMessage);
       
    }
}