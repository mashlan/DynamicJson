using System;
using System.Collections.Generic;
using Mashlan.DynamicJson.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Mashlan.DynamicJson.Api.Controllers
{
    [ApiVersion("1")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class QueueController : Controller
    {
        private readonly IQueueService queueService;

        public QueueController(IQueueService queueService)
        {
            this.queueService = queueService;
        }

        /// <summary>
        /// Returns all Queue records
        /// </summary>
        /// <returns><see cref="List{Queue}"/></returns>
        [HttpGet]
        [Route("all")]
        public IActionResult Get()
        {
            var list = queueService.GetAll();
            return new ObjectResult(list);
        }

        /// <summary>
        /// Returns a Queue record for the supplied Id
        /// </summary>
        /// <param name="id">Queue Id <see cref="Guid"/></param>
        /// <returns><see cref="Domain.Entities.Queue"/></returns>
        [HttpGet]
        [Route("/{id}")]
        public IActionResult Get(Guid id)
        {
            var que = queueService.Single();
            return new ObjectResult(que);
        }
    }
}