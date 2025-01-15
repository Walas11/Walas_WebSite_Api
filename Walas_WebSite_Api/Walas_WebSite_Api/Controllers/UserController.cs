using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Walas_WebSite_Api.Controllers
{
    [ApiController]
    [Route("UserApi/")]
    public class UserController : ControllerBase
    {
        // GET: api/<UserController>
        [HttpGet("GetUser")]
        public IEnumerable<string> Get()
        {
            return ["value1", "value2"];
        }

        // GET api/<UserController>/5
        [HttpGet("GetUser/{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // GET api/<UserController>/5
        [HttpGet("GetUserByLogin/{cedula}/{password}")]
        public string Get(int cedula, string Password)
        {
            return "value";
        }

        // POST api/<UserController>
        [HttpPost("PostUser")]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserController>/5
        [HttpPut("PutUser/{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("DeleteUser/{id}")]
        public void Delete(int id)
        {
        }
    }
}
