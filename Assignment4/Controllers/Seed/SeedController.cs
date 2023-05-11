using Hearthstone.DataAccess.MongoDbServices;
using Microsoft.AspNetCore.Mvc;

namespace Assignment4.Controllers.Seed
{
    [ApiController]
    public class SeedController : ControllerBase
    {
        private readonly SeedService _seedService;
        private readonly ILogger<SeedController> _logger;

        public SeedController(SeedService seedService, ILogger<SeedController> logger)
        {
            _seedService = seedService;
            _logger = logger;
        }

        [HttpPost("/seed")]
        public async Task<ActionResult> SeedMongoDb()
        {
            _logger.LogInformation("SeedMongoDb request received.");

            await _seedService.SeedMongoDb();

            _logger.LogInformation("SeedMongoDb request completed.");

            return Ok();
        }
    }
}
