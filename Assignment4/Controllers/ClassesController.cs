using Hearthstone.DataAccess.Models;
using Hearthstone.DataAccess.Service;
using Microsoft.AspNetCore.Mvc;

namespace Assignment4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassesController : ControllerBase
    {
        private readonly ClassService _service;

        public ClassesController(ClassService classService)
        {
            _service = classService;
        }

        [HttpGet("classes")]
        public async Task<IReadOnlyList<Class>> GetClasses()
        {
            return await _service.GetClasses();
        }
    }
}
