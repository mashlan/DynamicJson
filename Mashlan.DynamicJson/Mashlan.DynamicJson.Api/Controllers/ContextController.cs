using Mashlan.DynamicJson.Domain.Entities;
using Mashlan.DynamicJson.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Mashlan.DynamicJson.Api.Controllers
{
    /// <summary>
    /// Context REST Calls.
    /// </summary>
    [ApiVersion("1")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ContextController : Controller
    {
        private readonly IContextService contextService;

        public ContextController(IContextService contextService)
        {
            this.contextService = contextService;
        }

        /// <summary>
        /// Returns all Context records.
        /// </summary>
        /// <returns><see cref="IActionResult"/></returns>
        [HttpGet]
        [Route("all")]
        [ProducesResponseType(typeof(Context), 200)]
        public IActionResult Get()
        {
            var contexts = contextService.AsJObject();
            return new ObjectResult(contexts);
        }

        
    }
}