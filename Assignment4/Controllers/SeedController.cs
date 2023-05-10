using Hearthstone.DataAccess.Service;
using Microsoft.AspNetCore.Mvc;

namespace Assignment4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeedController : ControllerBase
    {
        private readonly MongoDbSeedService _mongoDbSeedService;

        public SeedController(MongoDbSeedService mongoDbSeedService)
        {
            _mongoDbSeedService = mongoDbSeedService;
        }

        // GET: api/<TestController>
        [HttpPost("/seed")]
        public async Task<ActionResult> SeedMongoDb()
        {
            await _mongoDbSeedService.SeedMongoDb();

            return Ok();
        }
    }
}
