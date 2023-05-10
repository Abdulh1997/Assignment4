using Hearthstone.DataAccess.Service;
using Microsoft.AspNetCore.Mvc;

namespace Assignment4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeedController : ControllerBase
    {
        private readonly MongoDbSeedService _mongoDbSeedService;
        private readonly ILogger<SeedController> _logger;
        
        public SeedController(MongoDbSeedService mongoDbSeedService, ILogger<SeedController> logger)
        {
            _mongoDbSeedService = mongoDbSeedService;
            _logger = logger;
        }

        [HttpPost("/seed")]
        public async Task<ActionResult> SeedMongoDb()
        {
            _logger.LogInformation("SeedMongoDb request received.");

            await _mongoDbSeedService.SeedMongoDb();

            _logger.LogInformation("SeedMongoDb request completed.");

            return Ok();
        }
    }
}
