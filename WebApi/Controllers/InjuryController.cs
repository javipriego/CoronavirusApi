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
    public class InjuryController : ControllerBase
    {
        private readonly IService<Injury> _injuryService;

        public InjuryController(IService<Injury> injuryService)
        {
            _injuryService = injuryService;
        }

        // GET api/values
        [HttpGet]
        [ProducesResponseType(typeof(List<Injury>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get()
        {
            var countries = await _injuryService.Get(); 
            var objectResult = new OkObjectResult(countries);

            return objectResult;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Injury), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Injury>> Get(Guid id)
        {
            var country = await _injuryService.Get(id);
            var objectResult = new OkObjectResult(country);

            return objectResult;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
