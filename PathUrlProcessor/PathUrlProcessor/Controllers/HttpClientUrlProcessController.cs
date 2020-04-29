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
        private SizeValidation SizeValidation { get; }

        public HttpClientUrlProcessController(HttpClientValidation httpClientValidation, SizeValidation sizeValidation)
        {
            HttpClientValidation = httpClientValidation;
            SizeValidation = sizeValidation;
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
            //If Any input url in the list is invalid -- IsValidUrl will return exception - which will be logged/handled in global exception filter
            if (inputObjects != null && inputObjects.All(x =>
                //URL Validation..
                HttpClientValidation.IsValidUrl(x).Result &&
                //Size Validation
                SizeValidation.isValidSize(x)))
            {
                return new JsonResult(inputObjects.ToDictionary(x => x.Path, o => new PathValueObject(o.Url, o.Size)));
            }

            return new JsonResult("Bad Request!");
        }
    }
}