using Hearthstone.DataAccess.MongoDbServices;
using Microsoft.AspNetCore.Mvc;

namespace Assignment4.Controllers.Class
{
    [ApiController]
    public class ClassesController : ControllerBase
    {
        private readonly ClassService _service;
        private readonly ILogger<ClassesController> _logger;

        public ClassesController(ClassService classService, ILogger<ClassesController> logger)
        {
            _service = classService;
            _logger = logger;
        }

        /// <summary>
        /// Gets classes
        /// </summary>
        /// <response code="200">Returns all classes</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("classes")]
        public async Task<IReadOnlyList<Hearthstone.DataAccess.Models.Class>> GetClasses()
        {
            _logger.LogInformation("GetClasses request received.");

            var classes = await _service.GetClasses();

            _logger.LogInformation($"GetClasses request completed. {classes.Count} classes found.");

            return classes;
        }
    }
}
