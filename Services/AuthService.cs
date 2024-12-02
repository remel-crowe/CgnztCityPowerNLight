using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.PowerPlatform.Dataverse.Client;
using Microsoft.Extensions.Configuration;


namespace CognizantDataverse.Services
{
    public class AuthService
    {
        private readonly IConfiguration _configuration;

        public AuthService(IConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            _configuration = configuration;
        }

        // Get an access token using username and password
        public async Task<string> GetAccessToken()
        {
            var tenantId = _configuration["Dataverse:TenantId"];
            var appId = _configuration["Dataverse:AppId"];
            var username = _configuration["Dataverse:Username"];
            var secretId = _configuration["Dataverse:SecretID"];
            var password = _configuration["Dataverse:Password"];
            var resource = _configuration["Dataverse:BaseUrl"];

            var url = $"https://login.microsoftonline.com/{tenantId}/oauth2/v2.0/token";
            var client = new HttpClient();
            var payload = new Dictionary<string, string>
            {
                { "grant_type", "password" },
                { "client_id", appId },
                { "client_secret", secretId },
                { "username", username },
                { "password", password },
                { "scope", resource }
            };
            
            
            var response = await client.PostAsync(url, new FormUrlEncodedContent(payload));
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var tokenResponse = JsonSerializer.Deserialize<AuthResponse>(jsonResponse);
            return tokenResponse.access_token;
        }
        
        public class AuthResponse
        {
            public string token_type { get; set; }
            public int expires_in { get; set; } // Numeric field
            public int ext_expires_in { get; set; } // Numeric field
            public string access_token { get; set; }
        }
    }
}