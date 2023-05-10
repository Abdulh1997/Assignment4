using Hearthstone.DataAccess.Models;
using Hearthstone.DataAccess.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Assignment4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RaritiesController : ControllerBase
    {

        private readonly RarityService _service;
        public RaritiesController(RarityService rarityService)
        {
            _service = rarityService;
        }

        [HttpGet("classes")]
        public async Task<IReadOnlyList<Rarity>> GetRarities()
        {
            return await _service.GetRarities();
        }

    }
}
