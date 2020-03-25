using Application.Contracts;
using Application.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorldController : ControllerBase
    {
        private readonly IService<World> _worldService;

        public WorldController(IService<World> worldService)
        {
            _worldService = worldService;
        }

        // GET api/values
        [HttpGet]
        [ProducesResponseType(typeof(List<World>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get()
        {
            var worlds = await _worldService.Get(); 
            var objectResult = new OkObjectResult(worlds);

            return objectResult;
        }
        
        [HttpGet("{startDateTime, endDateTime}")]
        [ProducesResponseType(typeof(List<World>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(DateTime startDateTime, DateTime endDateTime)
        {
            var worlds = await _worldService.Get();
            var objectResult = new OkObjectResult(worlds);

            return objectResult;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(World), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<World>> Get(Guid id)
        {
            var world = await _worldService.Get(id);
            var objectResult = new OkObjectResult(world);

            return objectResult;
        }
    }
}
