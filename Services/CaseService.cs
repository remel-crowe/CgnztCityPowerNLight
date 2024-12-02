using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using CognizantDataverse.Services;
using Microsoft.Extensions.Configuration;

namespace CognizantDataverse.Services
{
    public class CaseService(IConfiguration configuration, AuthService authService, HttpClient httpClient)
    {
        private readonly IConfiguration _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        private readonly AuthService _authService = authService ?? throw new ArgumentNullException(nameof(authService));
        private readonly HttpClient _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        
        public async Task GetCases()
        {
            var token = await _authService.GetAccessToken();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync("incidents");
            response.EnsureSuccessStatusCode();
        }
        // Get all cases (incidents)
    }
    
}
    
