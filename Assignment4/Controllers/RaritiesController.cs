using Assignment4.Modeles;
using Assignment4.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Assignment4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RaritiesController : ControllerBase
    {

        private readonly RaritieService _service;
        public RaritiesController(RaritieService raritieService)
        {
            _service = raritieService;
        }

        [HttpGet("classes")]
        public async Task<IList<Rarity>> GetRarities()
        {
            return await _service.GetRarities();
        }

    }
}
