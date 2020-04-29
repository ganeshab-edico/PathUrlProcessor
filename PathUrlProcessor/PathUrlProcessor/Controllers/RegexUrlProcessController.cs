using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Connections.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS;
using PathUrlProcessor.Model;
using PathUrlProcessor.Services;

namespace PathUrlProcessor.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegexUrlProcessController : ControllerBase
    {
        private RegexUrlValidation RegexUrlValidation { get; }

        public RegexUrlProcessController(RegexUrlValidation regexUrlValidation)
        {
            RegexUrlValidation = regexUrlValidation;
        }

        /// <summary>
        /// ASSUMPTION 1 - If any of the URL is invalid this endpoint will return error message!
        /// ASSUMPTION 2 - VALID SIZE -- Does this mean SIZE Should match byte value of the URL?
        /// Sorry I have had any incorrect assumption :) 
        /// </summary>
        /// <param name="inputObjects"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Post(List<InputObject> inputObjects)
        {
            if (inputObjects != null && inputObjects.All(x => RegexUrlValidation.IsValidUrl(x.Url)))
            {
                return new JsonResult(inputObjects.ToDictionary(x => x.Url, o => new PathValueObject(o.Url, o.Size)));
            }
            return new JsonResult("Bad Request!");
        }
    }
}