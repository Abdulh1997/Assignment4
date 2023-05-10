using Hearthstone.DataAccess.Models;
using Hearthstone.DataAccess.Service;
using Microsoft.AspNetCore.Mvc;


namespace Assignment4.Controllers
{
    [Route("api/[controller]")]
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

        [HttpGet("Types")]
        public async Task<IReadOnlyList<CardType>> GetTypes()
        {
            _logger.LogInformation("GetSets request received.");

            var types = await _service.GetTypes();

            _logger.LogInformation($"GetRarities request completed. {types.Count} sets found.");

            return types;
        }
    }
}
