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

        public TypesController(TypeService typeService)
        {
            _service = typeService;
        }
        
        [HttpGet("Types")]
        public async Task<IReadOnlyList<CardType>> GetTypes()
        {
            return await _service.GetTypes();
        }
    }
}
