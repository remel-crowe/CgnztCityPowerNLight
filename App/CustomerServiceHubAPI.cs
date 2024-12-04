using CognizantDataverse.Model;
using Microsoft.Xrm.Sdk;
using CognizantDataverse.Services;


namespace CognizantDataverse.App;

public class CustomerServiceHubApi(IOrganizationService dataverseConnection)
{
    private readonly AccountService _accountService = new AccountService(dataverseConnection);
    private readonly ContactService _contactService = new ContactService(dataverseConnection);
    private readonly CaseService _caseService = new CaseService(dataverseConnection);

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
            CustomerId = new EntityReference(Account.EntityLogicalName, demoAccount.Id),
            PrimaryContactId = new EntityReference(Contact.EntityLogicalName, demoContact.Id),
        };
        
        var updatedDemoAccount = new Account
        {
            Id = demoAccount.Id,
            Name = "Demo Account Updated",
            EMailAddress1 = "Demoaccount@mail.com",
            Telephone1 = "0987654321",
            Address1_Line1 = "Test Address Updated"
        };

        // Create the account and set the ID
        var createdAccountId = CreateAccount(demoAccount);
        demoAccount = GetAccountById(createdAccountId);
        
   
        
    }

    private Guid CreateAccount(Account account)
    {
        try
        {
            var createdAccountId = _accountService.CreateAccount(account);
            Console.WriteLine("Account created with ID: " + createdAccountId);
            return createdAccountId;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return Guid.Empty;
        }
    }
    
    private void UpdateAccount(Account account)
    {
        try
        {
            _accountService.UpdateAccount(account);
            Console.WriteLine("Account updated with ID: " + account.Id);
        } catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        
    }
    
    private void DeleteAccount(Guid accountId)
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
    
    private Account GetAccountById(Guid accountId)
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
    
    
    private void GetandPrintCases()
    {
        var cases = _caseService.GetCases();
        foreach (var @case in cases)
        {
            Console.WriteLine($"Case Title: {@case.Title} | Case ID: {@case.Id} | Case Customer: {@case.CustomerId.Name}");
        }
    }
    
    
    private Guid CreateContact(Contact contact)
    {
        try
        {
            var createdContactId = _contactService.CreateContact(contact);
            Console.WriteLine("Contact created with ID: " + createdContactId);
            return createdContactId;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return Guid.Empty;
        }
    }
    
    private void UpdateContact(Contact contact)
    {
        try
        {
            _contactService.UpdateContact(contact);
            Console.WriteLine("Contact updated with ID: " + contact.Id);
        } catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        
    }
    
    private void DeleteContact(Guid contactId)
    {
        try
        {
            _contactService.DeleteContact(contactId);
            Console.WriteLine("Contact deleted with ID: " + contactId);
        } catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        
    }
    
    
    
    
    
   
}
