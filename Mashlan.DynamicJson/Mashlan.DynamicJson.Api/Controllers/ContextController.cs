using Mashlan.DynamicJson.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Mashlan.DynamicJson.Api.Controllers
{
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

        [HttpGet]
        [Route("all")]
        public IActionResult Get()
        {
            var contexts = contextService.AsJObject();
            return new ObjectResult(contexts);
        }

        
    }
}