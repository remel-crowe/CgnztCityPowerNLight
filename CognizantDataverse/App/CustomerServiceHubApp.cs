using CognizantDataverse.Model;
using CognizantDataverse.Model.Entities;
using CognizantDataverse.Model.OptionSets;
using Microsoft.Xrm.Sdk;
using CognizantDataverse.Services;
using CognizantDataverse.Utilities;

//NOT A CONTROLLER - CHANGE NAME
namespace CognizantDataverse.App;
/// <summary>
/// Controller class for the Customer Service Hub application.
/// Handles the creation, retrieval, updating, and deletion of entities.
/// </summary>
/// <param name="dataverseConnection">An authorised connection instance to a Dataverse environment.</param>


public class CustomerServiceHubApp(IOrganizationService dataverseConnection)
{
    /// <summary>
    /// Demonstrates the creation, retrieval, updating, and deletion of entities.
    /// </summary>
    public void Demo()
{
    var accountService = new AccountService(dataverseConnection);
    var contactService = new ContactService(dataverseConnection);
    var caseService = new CaseService(dataverseConnection);

    // Create entities
    Console.WriteLine("Creating an account and contact...");
    var demoAccount = new Account
    {
        Name = "Big X Corp",
        Telephone1 = "1234567890",
        Address1_City = "Houston",
        EMailAddress1 = "mail@bigXcorp.com",
    };
    
    demoAccount.Id = CreateEntity(accountService, demoAccount);
    
    var demoContact = new Contact
    {
        FirstName = "Little",
        LastName = "X",
        EMailAddress1 = "littleX@mail.com",
        Telephone1 = "0987654321",    
        ParentCustomerId = new EntityReference(Account.EntityLogicalName, demoAccount.Id),
    };
    
    demoContact.Id = CreateEntity(contactService, demoContact);
    
   Console.WriteLine("\nAdding a contact to the account...");
   var updatedAccount = new Account
   {
       Id = demoAccount.Id,
       PrimaryContactId = new EntityReference(Contact.EntityLogicalName, demoContact.Id)
   };
   
   UpdateEntity(accountService, updatedAccount);
   
    Console.WriteLine("\nCreating an incident...");
    var demoIncident = new Incident
    {
        Title = "Demo Incident",
        Description = "This is a demo incident",
        CaseOriginCode = (incident_caseorigincode.Phone),
        CustomerId = new EntityReference(Account.EntityLogicalName, demoAccount.Id),
        PrimaryContactId = new EntityReference(Contact.EntityLogicalName, demoContact.Id)
    };
    demoIncident.Id = CreateEntity(caseService, demoIncident);

    // Retrieve and display created entities
    Console.WriteLine("\nRetrieving created entities...");
    EntityUtils.DisplayEntity(GetEntityById(accountService, demoAccount.Id));
    EntityUtils.DisplayEntity(GetEntityById(contactService, demoContact.Id));
    EntityUtils.DisplayEntity(GetEntityById(caseService, demoIncident.Id));

    // Update entities
    Console.WriteLine("\nUpdating Contact and Incident...");
    
    var updatedContact = new Contact
    {
        Id = demoContact.Id,
        FirstName = "Updated",
    };
    var updatedIncident = new Incident
    {
        Id = demoIncident.Id,
        Title = "Updated Incident",
        
        Description = "Updated description for the demo incident"
    };
    
    UpdateEntity(contactService, updatedContact);
    UpdateEntity(caseService, updatedIncident);

    // Retrieve and display updated entities
    Console.WriteLine("\nRetrieving updated entities...");
    EntityUtils.DisplayEntity(GetEntityById(contactService, demoContact.Id));
    EntityUtils.DisplayEntity(GetEntityById(caseService, demoIncident.Id));

    // Delete entities
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("\nIMPORTANT: The following actions will delete the entities created in this demo. If you'd like to verify them in the tables, please do so now.");
    Console.ResetColor();
    Console.WriteLine("Press any key to continue...");
    Console.ReadKey();
    Console.WriteLine("\nDeleting entities...");
    DeleteEntity(caseService, demoIncident.Id);
    DeleteEntity(contactService, demoContact.Id);
    DeleteEntity(accountService, demoAccount.Id);
    
    Console.WriteLine("Demo completed!");
}

    private Guid CreateEntity<T>(IService<T> service, T entity) where T : Entity
    {
        try
        {
            var createdEntityId = service.Create(entity);
            Console.WriteLine($"{typeof(T).Name} created with ID: " + createdEntityId);
            return createdEntityId;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }
    
    private T GetEntityById<T>(IService<T> service, Guid id) where T : Entity
    {
        try
        {
            var entity = service.GetById(id);
            Console.WriteLine($"{typeof(T).Name} retrieved with ID: " + entity.Id);
            return entity;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }
    
    private List<T> GetAllEntities<T>(IService<T> service) where T : Entity
    {
        try
        {
            var entities = service.GetAll();
            Console.WriteLine($"Retrieved all {typeof(T).Name} entities.");
            return entities;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }
    
    private void UpdateEntity<T>(IService<T> service, T entity) where T : Entity
    {
        try
        {
            service.Update(entity);
            Console.WriteLine($"{typeof(T).Name} updated with ID: " + entity.Id);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }
    
    private void DeleteEntity<T>(IService<T> service, Guid id) where T : Entity
    {
        try
        {
            service.Delete(id);
            Console.WriteLine($"{typeof(T).Name} deleted with ID: " + id);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }
    
    
   
}
