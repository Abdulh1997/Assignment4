using Hearthstone.DataAccess.Models;
using Hearthstone.DataAccess.Service;
using Microsoft.AspNetCore.Mvc;

namespace Assignment4.Controllers
{
    [Route("api/[controller]")]
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

        [HttpGet("sets")]
        public async Task<IReadOnlyList<Set>> GetSets()
        {
            _logger.LogInformation("GetSets request received.");

            var sets = await _service.GetSets();

            _logger.LogInformation($"GetSets request completed. {sets.Count} sets found.");

            return sets;
        }
    }
}
