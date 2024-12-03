using CognizantDataverse.Services;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using CognizantDataverse.Models;

namespace CognizantDataverse.Controllers
{
    public class AccountController
    {
        private readonly AccountService _accountService;

        public AccountController(IConfiguration configuration)
        {
            var authService = new AuthService(configuration);
            var token = authService.GetAccessToken().Result;

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            _accountService = new AccountService(configuration, httpClient);
        }
        
        //Create an account - CREATE
        public async Task<string> CreateAccount(string name, string email, string phone)
        {
            try
            {
                var account = await _accountService.CreateAccount(name, email, phone);
                return $"Account with ID {account} has been created.";
            }
            catch (Exception ex)
            {
                return $"Error creating account: {ex.Message}";
            }
        }
        
        //Get an account by ID - READ
        public async Task<Account> GetAccountById(string id)
        {
            try
            {
                var account = await _accountService.GetAccountById(id);
                return account;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error Fetching Account: {ex.Message}");
            }
        }
        
        //Get all accounts - READ
        public async Task<List<Account>> GetAllAccounts()
        {
            try
            {
                var accounts = await _accountService.GetAllAccounts();
                return accounts;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error Fetching Accounts: {ex.Message}");
            }
        }
        
        //Update an account by ID - UPDATE
        public async Task<string> UpdateAccountById(string id, string name, string email, string phone)
        {
            try
            {
                await _accountService.UpdateAccount(id, name, email, phone);
                return $"Account {id} has been updated.";
            }
            catch (Exception ex)
            {
                return $"Error Updating Account: {ex.Message}";
            }
        }
        
        //Delete an account by ID - DELETE
        public async Task<string> DeleteAccountById(string id)
        {
            try
            {
                await _accountService.DeleteAccount(id);
                return $"Account {id} has been deleted.";
                
            }
            catch (Exception ex)
            {
                return $"Failed to delete user: {ex.Message}";
            }
        }
        
        
        
    }
}