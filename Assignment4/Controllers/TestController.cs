using Assignment4.Service;
using Microsoft.AspNetCore.Mvc;


namespace Assignment4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private MongoService _mongoService;

        public TestController(MongoService mongoService)
        { 
          _mongoService = mongoService;
        }

        // GET: api/<TestController>
        [HttpGet("/Update Databasen")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
