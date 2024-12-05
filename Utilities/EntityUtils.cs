using CognizantDataverse.Model;
using Microsoft.Xrm.Sdk;

namespace CognizantDataverse.Utilities;

/// <summary>
/// Utility class which provides methods to interact with retrieved entities.
/// </summary>
public static class EntityUtils
{
    /// <summary>
    ///  Displays the details of an account entity.
    /// </summary>
    /// <param name="account">Entity of type Account</param>
    
    public static void DisplayEntity(Account account)
    {
        Console.WriteLine($"Name: {account.Name}");
        Console.WriteLine($"Email: {account.EMailAddress1}");
        Console.WriteLine($"Phone: {account.Telephone1}");
        Console.WriteLine("-------------------------------");
    }
    
    /// <summary>
    ///  Displays the details of a contact entity.
    /// </summary>
    /// <param name="contact">Entity of type Contact</param>
    public static void DisplayEntity(Contact contact)
    {
        Console.WriteLine($"Name: {contact.FirstName} {contact.LastName}");
        Console.WriteLine($"Email: {contact.EMailAddress1}");
        Console.WriteLine($"Phone: {contact.Telephone1}");
        Console.WriteLine($"Parent Account: {contact.ParentCustomerId?.Name}");
        Console.WriteLine("-------------------------------");
    }
    /// <summary>
    /// Displays the details of an incident entity.
    /// </summary>
    /// <param name="incident">Entity of type Incident</param>
    public static void DisplayEntity(Incident incident)
    {
        Console.WriteLine($"Title: {incident.Title}");
        Console.WriteLine($"Description: {incident.Description}");
        Console.WriteLine($"Customer: {incident.CustomerId?.Name}");
        Console.WriteLine($"Primary Contact: {incident.PrimaryContactId?.Name}");
        Console.WriteLine($"Created On: {incident.CreatedOn}");
        Console.WriteLine("-------------------------------");
    }
}