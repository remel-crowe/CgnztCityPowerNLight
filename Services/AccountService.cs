using CognizantDataverse.Models;
using CognizantDataverse.Utilities;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace CognizantDataverse.Services
{
    public class AccountService(IConfiguration configuration, HttpClient httpClient)
    {
        private readonly IConfiguration _configuration = configuration;
        private readonly HttpClient _httpClient = httpClient;

        public async Task<string> CreateAccount(string fname, string email, string phone)
        {
            var url = $"https://orgff19c007.crm11.dynamics.com/api/data/v9.2/accounts";
            var payload = new
            {
                name = fname,
                emailaddress1 = email,
                telephone1 = phone
            };
            var response = await HttpRequestUtility.MakeHttpRequest(_httpClient, HttpMethod.Post, url, payload);
            return JsonSerializer.Deserialize<Account>(response).Id;
        }
        public async Task<Account> GetAccountById(string accountId)
        {
            var url = $"https://orgff19c007.crm11.dynamics.com/api/data/v9.2/accounts({accountId})";
            var response = await HttpRequestUtility.MakeHttpRequest(_httpClient, HttpMethod.Get, url);
            return JsonSerializer.Deserialize<Account>(response);
        }
        
        public async Task<List<Account>> GetAllAccounts()
        {
            var url = $"https://orgff19c007.crm11.dynamics.com/api/data/v9.2/accounts";
            var response = await HttpRequestUtility.MakeHttpRequest(_httpClient, HttpMethod.Get, url);
            var jsonResponse = JsonSerializer.Deserialize<JsonElement>(response);
            var accounts = JsonSerializer.Deserialize<List<Account>>(jsonResponse.GetProperty("value").GetRawText());
            return accounts;
        }
        
        public async Task<string> UpdateAccount(string accountId, string name, string email, string phone)
        {
            var url = $"https://orgff19c007.crm11.dynamics.com/api/data/v9.2/accounts({accountId})";
            var payload = new
            {
                name = name,
                emailaddress1 = email,
                telephone1 = phone
            };
            return await HttpRequestUtility.MakeHttpRequest(_httpClient, HttpMethod.Patch, url, payload);
        }
        
        public async Task<string> DeleteAccount(string accountId)
        {
            var url = $"https://orgff19c007.crm11.dynamics.com/api/data/v9.2/accounts({accountId})";
            return await HttpRequestUtility.MakeHttpRequest(_httpClient, HttpMethod.Delete, url);
        }
    }
}