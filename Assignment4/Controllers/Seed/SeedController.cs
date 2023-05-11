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

        /// <summary>
        /// Seeds MongoDB with data if no data exists
        /// </summary>
        /// <response code="200">Seed complete</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
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
