using System.Collections.Generic;
using Hex.Event.Core.Domain.Entities.Dtos;
using Hex.Event.Core.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hex.Event.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ICourseService _courseService;
        public ValuesController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            _courseService.Resgister(new SubscribeInputDto { Course = "CursoA", Email = "dumorro@gmail.com", Name = "Dumorro" });
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
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
