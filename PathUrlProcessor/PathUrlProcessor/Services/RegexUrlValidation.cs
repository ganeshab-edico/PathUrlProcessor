using System;
using System.Text.RegularExpressions;
using PathUrlProcessor.Model;

namespace PathUrlProcessor.Services
{
    public class RegexUrlValidation
    {
        public bool IsValidUrl(InputObject inputObject)
        {
            if (Uri.IsWellFormedUriString(inputObject.Url, UriKind.Absolute))
                return true;
            throw new Exception($"{inputObject.Url} is Invalid for {inputObject}");
        }
    }
}