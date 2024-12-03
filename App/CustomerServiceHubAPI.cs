using CognizantDataverse.Model;
using Microsoft.Xrm.Sdk;
using CognizantDataverse.Services;
using Microsoft.Extensions.Configuration;


namespace CognizantDataverse.App;

public class CustomerServiceHubAPI(IOrganizationService configuration)
{
    private readonly AccountService _accountService = new AccountService(configuration);
    private readonly ContactService _contactService = new ContactService(configuration);
    private readonly CaseService _caseService = new CaseService(configuration);

    public void Demo()
    {
        var demoAccount = new Account
        {
            Name = "Demo Account",
            EMailAddress1 = "Demoaccount@mail.com",
            Telephone1 = "1234567890",
            Address1_Line1 = "Test Address",
            Address1_PostalCode = "12345",
        };

        var demoContact = new Contact
        {
            FirstName = "Demo",
            LastName = "Contact",
            EMailAddress1 = "democontact@mail.com",
            Telephone1 = "0987654321",
        };
        
        var demoIncident = new Incident
        {
            Title = "Demo Incident",
            Description = "This is a demo incident",
            CustomerId = new EntityReference(Account.EntityLogicalName, Guid.NewGuid()),
            ContactId = {}
        };
        
        GetAndPrintAccounts();
        CreateAccount(demoAccount);
        GetAndPrintAccounts();
        // DeleteAccount();
        GetAndPrintAccounts();
        
        
        
    }
    
    
    
    public void CreateAccount(Account account)
    {
        try
        { 
            var createdAccountID= _accountService.CreateAccount(account);
            Console.WriteLine("Account created with ID: " + createdAccountID);
        } catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        
    }
    
    public void UpdateAccount(Account account)
    {
        _accountService.UpdateAccount(account);
    }
    
    public void DeleteAccount(Guid accountId)
    {
        try
        {
            _accountService.DeleteAccount(accountId);
            Console.WriteLine("Account deleted with ID: " + accountId);
        } catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        
    }
    
    public Account GetAccountById(Guid accountId)
    {
        return _accountService.GetAccountById(accountId);
    }
    
    private void GetAndPrintAccounts()
    {
        var accounts = _accountService.GetAccounts();
        foreach (var account in accounts)
        {
            Console.WriteLine($"Account Name: {account.Name} | Account ID: {account.Id}");
        }
    }
    
}
