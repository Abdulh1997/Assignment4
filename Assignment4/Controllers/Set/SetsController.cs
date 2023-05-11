using Hearthstone.DataAccess.MongoDbServices;
using Microsoft.AspNetCore.Mvc;

namespace Assignment4.Controllers.Set
{
    [ApiController]
    public class SetsController : ControllerBase
    {
        private readonly SetsService _service;
        private readonly ILogger<SetsController> _logger;

        public SetsController(SetsService setService, ILogger<SetsController> logger)
        {
            _service = setService;
            _logger = logger;
        }

        /// <summary>
        /// Gets card-sets
        /// </summary>
        /// <response code="200">Returns all sets</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("sets")]
        public async Task<IReadOnlyList<Hearthstone.DataAccess.Models.Set>> GetSets()
        {
            _logger.LogInformation("GetSets request received.");

            var sets = await _service.GetSets();

            _logger.LogInformation($"GetSets request completed. {sets.Count} sets found.");

            return sets;
        }
    }
}
