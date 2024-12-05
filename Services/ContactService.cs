using CognizantDataverse.Model;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace CognizantDataverse.Services;

/// <summary>
/// Service class to perform CRUD operations on Contact entities within the Dataverse environment.
/// </summary>
public class ContactService(IOrganizationService dataverseConnection) : IService<Contact>
{
    private readonly IOrganizationService _dataverseConnection = dataverseConnection;

    /// <summary>
    /// Creates a new contact in the Dataverse environment.
    /// </summary>
    /// <param name="contact">The contact entity to be created.</param>
    /// <returns>The unique identifier (GUID) of the created contact.</returns>
    public Guid Create(Contact contact)
    {
        try
        {
            return _dataverseConnection.Create(contact);
        }
        catch (Exception ex)
        {
            throw new Exception($"Error creating contact: {ex.Message}", ex);
        }
    }

    /// <summary>
    /// Retrieves a contact by its unique identifier.
    /// </summary>
    /// <param name="contactId">The unique identifier (GUID) of the contact to retrieve.</param>
    /// <returns>The contact entity with the specified identifier.</returns>
    public Contact GetById(Guid contactId)
    {
        try
        {
            return (Contact)_dataverseConnection.Retrieve(Contact.EntityLogicalName, contactId, new ColumnSet(true));
        } 
        catch (Exception ex)
        {
            throw new Exception($"Error retrieving contact: {ex.Message}", ex);
        }
        
    }

    /// <summary>
    /// Updates an existing contact in the Dataverse environment.
    /// </summary>
    /// <param name="contact">The contact entity with updated information.</param>
    public void Update(Contact contact)
    {
        try
        {
            _dataverseConnection.Update(contact);
        }
        catch (Exception ex)
        {
            throw new Exception($"Error updating contact: {ex.Message}", ex);
        }
        
    }

    /// <summary>
    /// Deletes a contact from the Dataverse environment.
    /// </summary>
    /// <param name="contactId">The unique identifier (GUID) of the contact to delete.</param>
    public void Delete(Guid contactId)
    {
        try
        {
            _dataverseConnection.Delete(Contact.EntityLogicalName, contactId);
        }
        catch (Exception ex)
        {
            throw new Exception($"Error deleting contact: {ex.Message}", ex);
        }
        
    }

    /// <summary>
    /// Retrieves all contacts from the Dataverse environment.
    /// </summary>
    /// <returns>A list of all contact entities.</returns>
    public List<Contact> GetAll()
    {
        var query = new QueryExpression(Contact.EntityLogicalName)
        {
            ColumnSet = new ColumnSet(true)
        };

        return _dataverseConnection
                .RetrieveMultiple(query).Entities
                .Select(entity => entity.ToEntity<Contact>()).ToList();
    }
}