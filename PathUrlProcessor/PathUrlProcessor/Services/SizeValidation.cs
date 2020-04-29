using System;
using System.Net.Http;
using System.Security.Policy;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Server.IIS.Core;
using PathUrlProcessor.Model;

namespace PathUrlProcessor.Services
{
    /// <summary>
    /// Sorry but I am not sure what does Valid Size mean?
    /// Assumption 1 - Size > 0?
    /// Assumption 2 - Size ==  GetByte(url) ?
    /// I will give this a retry - if you can provide some information. :) 
    /// </summary>
    public class SizeValidation
    {
        public bool isValidSize(InputObject inputObject)
        {
            if (inputObject.Size > 0)
                return true;
            // FYI Override ToString Method -- InputObject
            throw new Exception($"Size - {inputObject.Size} is Invalid for {inputObject}");
        }

    }
}