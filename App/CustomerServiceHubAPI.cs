using CognizantDataverse.Model;
using Microsoft.Xrm.Sdk;
using CognizantDataverse.Services;


namespace CognizantDataverse.App;

public class CustomerServiceHubApi(IOrganizationService dataverseConnection)
{
    public void Demo()
{
    var accountService = new AccountService(dataverseConnection);
    var contactService = new ContactService(dataverseConnection);
    var caseService = new CaseService(dataverseConnection);

    // Create entities
    Console.WriteLine("Creating entities...");
    var demoAccount = new Account
    {
        Name = "Demo Account",
        EMailAddress1 = "Demoaccount@mail.com",
        Telephone1 = "1234567890",
    };
    
    demoAccount.Id = CreateEntity(accountService, demoAccount);
    
    var demoContact = new Contact
    {
        FirstName = "Demo",
        LastName = "Contact",
        EMailAddress1 = "democontact@mail.com",
        Telephone1 = "0987654321",
        ParentCustomerId = new EntityReference(Account.EntityLogicalName, demoAccount.Id)
    };
    
    var demoIncident = new Incident
    {
        Title = "Demo Incident",
        Description = "This is a demo incident",
        CustomerId = new EntityReference(Account.EntityLogicalName, demoAccount.Id),
        PrimaryContactId = new EntityReference(Contact.EntityLogicalName, demoContact.Id)
    };
    
    demoContact.Id = CreateEntity(contactService, demoContact);

    demoIncident.CustomerId = new EntityReference(Account.EntityLogicalName, demoAccount.Id);
    demoIncident.PrimaryContactId = new EntityReference(Contact.EntityLogicalName, demoContact.Id);
    demoIncident.Id = CreateEntity(caseService, demoIncident);

    // Retrieve and display created entities
    Console.WriteLine("\nRetrieving created entities...");
    DisplayEntity(GetEntityById(accountService, demoAccount.Id));
    DisplayEntity(GetEntityById(contactService, demoContact.Id));
    DisplayEntity(GetEntityById(caseService, demoIncident.Id));

    // Update entities
    Console.WriteLine("\nUpdating entities...");
    var updatedAccount = new Account
    {
        Id = demoAccount.Id,
        Name = "Updated Demo Account",
        Telephone1 = "1112223333"
    };
    var updatedContact = new Contact
    {
        Id = demoContact.Id,
        FirstName = "Updated Demo Contact",
    };
    var updatedIncident = new Incident
    {
        Id = demoIncident.Id,
        Title = "Updated Incident",
        Description = "Updated description for the demo incident"
    };

    UpdateEntity(accountService, updatedAccount);
    UpdateEntity(contactService, updatedContact);
    UpdateEntity(caseService, updatedIncident);

    // Retrieve and display updated entities
    Console.WriteLine("\nRetrieving updated entities...");
    DisplayEntity(GetEntityById(accountService, demoAccount.Id));
    DisplayEntity(GetEntityById(contactService, demoContact.Id));
    DisplayEntity(GetEntityById(caseService, demoIncident.Id));

    // Delete entities
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
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return Guid.Empty;
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
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return null;
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
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return null;
        }
    }
    
    private void UpdateEntity<T>(IService<T> service, T entity) where T : Entity
    {
        try
        {
            service.Update(entity);
            Console.WriteLine($"{typeof(T).Name} updated with ID: " + entity.Id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    
    private void DeleteEntity<T>(IService<T> service, Guid id) where T : Entity
    {
        try
        {
            service.Delete(id);
            Console.WriteLine($"{typeof(T).Name} deleted with ID: " + id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    
    
    private void DisplayEntity<T>(T entity) where T : Entity
    {
        if (entity == null)
        {
            Console.WriteLine($"{typeof(T).Name} could not be found.");
            return;
        }

        Console.WriteLine($"Entity: {typeof(T).Name}");
        
        if (entity is Account account)
        {
            Console.WriteLine($"Name: {account.Name}");
            Console.WriteLine($"Email: {account.EMailAddress1}");
            Console.WriteLine($"Phone: {account.Telephone1}");
        }
        else if (entity is Contact contact)
        {
            Console.WriteLine($"Name: {contact.FirstName} {contact.LastName}");
            Console.WriteLine($"Email: {contact.EMailAddress1}");
            Console.WriteLine($"Phone: {contact.Telephone1}");
        }
        else if (entity is Incident incident)
        {
            Console.WriteLine($"Title: {incident.Title}");
            Console.WriteLine($"Description: {incident.Description}");
            Console.WriteLine($"Customer: {incident.CustomerId?.Name}");
            Console.WriteLine($"Primary Contact: {incident.PrimaryContactId?.Name}");
        }

        Console.WriteLine("-------------------------------");
    }
   
}
