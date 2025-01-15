using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Walas_WebSite_Api.Controllers
{
    [Route("api/EventManagement")]
    [ApiController]
    public class TechnicalTestEventManagementController : ControllerBase
    {
        // GET: api/<TechnicalTestEventManagementController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<TechnicalTestEventManagementController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TechnicalTestEventManagementController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TechnicalTestEventManagementController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TechnicalTestEventManagementController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
