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
    public class ContinentController : ControllerBase
    {
        private readonly IService<Continent> _continentService;

        public ContinentController(IService<Continent> continentService)
        {
            _continentService = continentService;
        }

        // GET api/values
        [HttpGet]
        [ProducesResponseType(typeof(List<Continent>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get()
        {
            var worlds = await _continentService.Get(); 
            var objectResult = new OkObjectResult(worlds);

            return objectResult;
        }
        
        [HttpGet("{startDateTime, endDateTime}")]
        [ProducesResponseType(typeof(List<Continent>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(DateTime startDateTime, DateTime endDateTime)
        {
            var worlds = await _continentService.Get();
            var objectResult = new OkObjectResult(worlds);

            return objectResult;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Continent), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Continent>> Get(Guid id)
        {
            var world = await _continentService.Get(id);
            var objectResult = new OkObjectResult(world);

            return objectResult;
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<Continent>> Post(Continent value)
        {
            await _continentService.Insert(value);
            var objectResult = new OkObjectResult(value);

            return objectResult;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
