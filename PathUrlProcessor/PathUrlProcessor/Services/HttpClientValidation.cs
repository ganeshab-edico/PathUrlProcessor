using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PathUrlProcessor.Services
{
    public class HttpClientValidation
    {
        private HttpClient Client { get; }

        public HttpClientValidation(HttpClient client)
        {
            Client = client;
        }

        public async Task<bool> IsValidUrl(string url)
        {
            return (await Client.GetAsync(url)).IsSuccessStatusCode;
        }
    }
}