using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using PathUrlProcessor.Model;

namespace PathUrlProcessor.Services
{
    public class HttpClientValidation
    {
        private IHttpClientFactory ClientFactory { get; }

        public HttpClientValidation(IHttpClientFactory client)
        {
            ClientFactory = client;
        }

        public async Task<bool> IsValidUrl(InputObject inputObject)
        {
            if ((await ClientFactory.CreateClient().GetAsync(inputObject.Url)).IsSuccessStatusCode)
                return true;
            throw new Exception($"{inputObject.Url} is Invalid for {inputObject}");
        }
    }
}