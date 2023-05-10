using Hearthstone.DataAccess.Models;
using Hearthstone.DataAccess.Service;
using Microsoft.AspNetCore.Mvc;

namespace Assignment4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RaritiesController : ControllerBase
    {
        private readonly RarityService _service;
        private readonly ILogger<RaritiesController> _logger;

        public RaritiesController(RarityService rarityService, ILogger<RaritiesController> logger)
        {
            _service = rarityService;
            _logger = logger;
        }

        [HttpGet("classes")]
        public async Task<IReadOnlyList<Rarity>> GetRarities()
        {
            _logger.LogInformation("GetRarities request received.");

            var rarities = await _service.GetRarities();

            _logger.LogInformation($"GetRarities request completed. {rarities.Count} rarities found.");

            return rarities;
        }
    }
}
