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
    public class CountryController : ControllerBase
    {
        private readonly IService<Country> _countryService;

        public CountryController(IService<Country> countryService)
        {
            _countryService = countryService;
        }

        // GET api/values
        [HttpGet]
        [ProducesResponseType(typeof(List<Country>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get()
        {
            var countries = await _countryService.Get(); 
            var objectResult = new OkObjectResult(countries);

            return objectResult;
        }
        
        [HttpGet("{startDateTime, endDateTime}")]
        [ProducesResponseType(typeof(List<Country>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(DateTime startDateTime, DateTime endDateTime)
        {
            var countries = await _countryService.Get();
            var objectResult = new OkObjectResult(countries);

            return objectResult;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Country), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Country>> Get(Guid id)
        {
            var country = await _countryService.Get(id);
            var objectResult = new OkObjectResult(country);

            return objectResult;
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<Country>> Post(Country value)
        {
            await _countryService.Insert(value);
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
