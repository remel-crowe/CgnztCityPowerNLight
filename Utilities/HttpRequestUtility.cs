using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CognizantDataverse.Utilities
{
    public static class HttpRequestUtility
    {
        public static async Task<string> MakeHttpRequest(HttpClient httpClient, HttpMethod method, string url, object payload = null)
        {
            var request = new HttpRequestMessage(method, url);
            if (payload != null)
            {
                var json = JsonSerializer.Serialize(payload);
                request.Content = new StringContent(json, Encoding.UTF8, "application/json");
            }

            var response = await httpClient.SendAsync(request);
            ThrowExceptionIfError(response);
            return await response.Content.ReadAsStringAsync();
        }

        private static void ThrowExceptionIfError(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                switch (response.StatusCode)
                {
                    case System.Net.HttpStatusCode.NotFound:
                        throw new HttpRequestException("Resource not found.");
                    case System.Net.HttpStatusCode.BadRequest:
                        throw new HttpRequestException("Bad request.");
                    case System.Net.HttpStatusCode.Unauthorized:
                        throw new HttpRequestException("Unauthorised.");
                    case System.Net.HttpStatusCode.Forbidden:
                        throw new HttpRequestException("Forbidden.");
                    case System.Net.HttpStatusCode.InternalServerError:
                        throw new HttpRequestException("Internal server error.");
                    default:
                        throw new HttpRequestException($"Failed to retrieve account. Status code: {response.StatusCode}");
                    
                }
            }
        }
    }
}