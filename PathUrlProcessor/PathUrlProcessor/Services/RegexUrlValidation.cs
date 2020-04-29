using System;
using System.Text.RegularExpressions;
using PathUrlProcessor.Model;

namespace PathUrlProcessor.Services
{
    public class RegexUrlValidation
    {
        public bool IsValidUrl(InputObject inputObject)
        {
            const string urlRegexPattern = @"^http(s)?://([\w-]+.)+[\w-]+(/[\w- ./?%&=])?$";
            if (Regex.IsMatch(inputObject.Url, urlRegexPattern))
                return true;
            throw new Exception($"{inputObject.Url} is Invalid for {inputObject}");
        }
    }
}