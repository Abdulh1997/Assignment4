using Assignment4.Modeles;
using Assignment4.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Assignment4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SetsController : ControllerBase
    {
        private readonly SetsService _service;
        public SetsController(SetsService setService)
        {
            _service = setService;
        }


        [HttpGet("classes")]
        public async Task<IList<Set>> GetSets()
        {
            return await _service.GetSets();
        }
    }
}
