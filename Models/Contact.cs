using System;
using System.Text.Json.Serialization;
using CognizantDataverse.Interfaces;


namespace CognizantDataverse.Models;


public class Contact : IPrintable
{
    
    [JsonPropertyName("contactid")]
    public string Id { get; set; }

    [JsonPropertyName("firstname")]
    public string FirstName { get; set; }

    [JsonPropertyName("lastname")]
    public string LastName { get; set; }

    [JsonPropertyName("emailaddress1")]
    public string Email { get; set; }

    [JsonPropertyName("mobilephone")]
    public string Phone { get; set; }

    public Contact(string firstName, string lastName, string email, string phone)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Phone = phone;
    }
    
    public void Print()
    {
        Console.WriteLine($"Id: {Id}, First Name: {FirstName}, Last Name: {LastName}, Email: {Email}, Phone: {Phone}");
    }
}