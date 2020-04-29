using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PathUrlProcessor.Model;
using PathUrlProcessor.Services;

namespace PathUrlProcessor.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HttpClientUrlProcessController : ControllerBase
    {
        private HttpClientValidation HttpClientValidation { get; }

        public HttpClientUrlProcessController(HttpClientValidation httpClientValidation)
        {
            HttpClientValidation = httpClientValidation;
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
            if (inputObjects != null && inputObjects.All(x => HttpClientValidation.IsValidUrl(x.Url).Result))
            {
                return new JsonResult(inputObjects.ToDictionary(x => x.Url, o => new PathValueObject(o.Url, o.Size)));
            }

            return new JsonResult("Bad Request!");
        }
    }
}