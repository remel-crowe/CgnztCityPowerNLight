using System.Text.Json.Serialization;
using CognizantDataverse.Interfaces;


namespace CognizantDataverse.Models
{
    public class Account : IPrintable
    {
        [JsonPropertyName("accountid")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("emailaddress1")]
        public string Email { get; set; }

        [JsonPropertyName("telephone1")]
        public string Phone { get; set; }

        public Account(string name, string email, string phone)
        {
            Name = name;
            Email = email;
            Phone = phone;
        }
        
        public void Print()
        {
            Console.WriteLine($"Id: {Id}, Name: {Name}, Email: {Email}, Phone: {Phone}");
        }
    }
}