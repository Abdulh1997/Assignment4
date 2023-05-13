using Hearthstone.DataAccess.MongoDbServices;
using Microsoft.AspNetCore.Mvc;

namespace Assignment4.Controllers.Seed
{
    [ApiController]
    public class SeedController : ControllerBase
    {
        private readonly MongoDbService _mongoDbService;
        private readonly ILogger<SeedController> _logger;

        public SeedController(MongoDbService mongoDbService, ILogger<SeedController> logger)
        {
            _mongoDbService = mongoDbService ?? throw new ArgumentNullException(nameof(mongoDbService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
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

            await _mongoDbService.SeedMongoDb();

            _logger.LogInformation("SeedMongoDb request completed.");

            return Ok();
        }
    }
}
