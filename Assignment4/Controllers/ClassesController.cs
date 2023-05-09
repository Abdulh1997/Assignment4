using Assignment4.Modeles;
using Assignment4.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        public async Task<IList<Class>> GetClasses()
        {
            return await _service.GetClasses();
        }
    }
}
