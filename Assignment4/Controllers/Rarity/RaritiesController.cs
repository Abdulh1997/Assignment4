using Hearthstone.DataAccess.MongoDbServices;
using Microsoft.AspNetCore.Mvc;

namespace Assignment4.Controllers.Rarity
{
    [ApiController]
    public class RaritiesController : ControllerBase
    {
        private readonly RarityService _service;
        private readonly ILogger<RaritiesController> _logger;

        public RaritiesController(RarityService rarityService, ILogger<RaritiesController> logger)
        {
            _service = rarityService ?? throw new ArgumentNullException(nameof(rarityService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Gets card-rarities
        /// </summary>
        /// <response code="200">Returns all rarities</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("rarities")]
        public async Task<IReadOnlyList<Hearthstone.DataAccess.Models.Rarity>> GetRarities()
        {
            _logger.LogInformation("GetRarities request received.");

            var rarities = await _service.GetRarities();

            _logger.LogInformation($"GetRarities request completed. {rarities.Count} rarities found.");

            return rarities;
        }
    }
}
