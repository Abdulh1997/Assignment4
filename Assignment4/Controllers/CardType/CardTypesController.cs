using Hearthstone.DataAccess.MongoDbServices;
using Microsoft.AspNetCore.Mvc;


namespace Assignment4.Controllers.CardType
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardTypesController : ControllerBase
    {
        private readonly TypeService _service;
        private readonly ILogger<CardTypesController> _logger;

        public CardTypesController(TypeService typeService, ILogger<CardTypesController> logger)
        {
            _service = typeService;
            _logger = logger;
        }

        [HttpGet("Types")]
        public async Task<IReadOnlyList<Hearthstone.DataAccess.Models.CardType>> GetTypes()
        {
            _logger.LogInformation("GetSets request received.");

            var types = await _service.GetTypes();

            _logger.LogInformation($"GetRarities request completed. {types.Count} sets found.");

            return types;
        }
    }
}
