using CognizantDataverse.Model;


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
        Console.WriteLine($"Phone: {account.Telephone1}");
        Console.WriteLine($"City: {account.Address1_City}");
        Console.WriteLine($"Primary Contact: {account.PrimaryContactId.Name}");
        Console.WriteLine("-------------------------------");
    }
    
    /// <summary>
    ///  Displays the details of a contact entity.
    /// </summary>
    /// <param name="contact">Entity of type Contact</param>
    public static void DisplayEntity(Contact contact)
    {
        Console.WriteLine($"Full Name: {contact.FullName}");
        Console.WriteLine($"Email: {contact.EMailAddress1}");
        Console.WriteLine($"Company: {contact.ParentCustomerId?.Name}");
        Console.WriteLine($"Phone: {contact.Telephone1}");
        Console.WriteLine("-------------------------------");
    }
    /// <summary>
    /// Displays the details of an incident entity.
    /// </summary>
    /// <param name="incident">Entity of type Incident</param>
    public static void DisplayEntity(Incident incident)
    {
        Console.WriteLine($"Title: {incident.Title}");
        Console.WriteLine($"Case Number: {incident.TicketNumber}");
        Console.WriteLine($"Priority: {incident.PriorityCode}");
        Console.WriteLine($"Origin: {incident.CaseOriginCode}");
        Console.WriteLine($"Customer: {incident.CustomerId.Name}");
        Console.WriteLine($"Status : {incident.StateCode}");
        Console.WriteLine($"Created On: {incident.CreatedOn}");
        Console.WriteLine("-------------------------------");
    }
}