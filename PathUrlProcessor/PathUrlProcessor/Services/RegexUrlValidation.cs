using System.Net.Http;
using System.Security.Policy;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PathUrlProcessor.Services
{
    public class RegexUrlValidation
    {
        public bool IsValidUrl(string url)
        {
            const string urlRegexPattern = @"^http(s)?://([\w-]+.)+[\w-]+(/[\w- ./?%&=])?$";
            return Regex.IsMatch(url, urlRegexPattern);
        }
    }
}