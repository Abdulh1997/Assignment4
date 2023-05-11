using Hearthstone.DataAccess.MongoDbServices;
using Microsoft.AspNetCore.Mvc;

namespace Assignment4.Controllers.Type
{
    [ApiController]
    public class TypesController : ControllerBase
    {
        private readonly TypeService _service;
        private readonly ILogger<TypesController> _logger;

        public TypesController(TypeService typeService, ILogger<TypesController> logger)
        {
            _service = typeService;
            _logger = logger;
        }

        /// <summary>
        /// Gets card-types
        /// </summary>
        /// <response code="200">Returns all types</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("types")]
        public async Task<IReadOnlyList<Hearthstone.DataAccess.Models.CardType>> GetTypes()
        {
            _logger.LogInformation("GetSets request received.");

            var types = await _service.GetTypes();

            _logger.LogInformation($"GetRarities request completed. {types.Count} sets found.");

            return types;
        }
    }
}
