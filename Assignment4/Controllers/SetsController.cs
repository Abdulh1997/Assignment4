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
        public SetsController(SetsService setService)
        {
            _service = setService;
        }

        [HttpGet("classes")]
        public async Task<IReadOnlyList<Set>> GetSets()
        {
            return await _service.GetSets();
        }
    }
}
