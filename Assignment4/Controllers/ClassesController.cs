using Hearthstone.DataAccess.Models;
using Hearthstone.DataAccess.MongoDbServices;
using Microsoft.AspNetCore.Mvc;

namespace Assignment4.Controllers
{
    [Route("api/[controller]")]
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

        [HttpGet("classes")]
        public async Task<IReadOnlyList<Class>> GetClasses()
        {
            _logger.LogInformation("GetClasses request received.");

            var classes = await _service.GetClasses();

            _logger.LogInformation($"GetClasses request completed. {classes.Count} classes found.");

            return classes;
        }
    }
}
