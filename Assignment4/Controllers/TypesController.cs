using Assignment4.Modeles;
using Assignment4.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        public async Task<IList<CardType>> GetTypes()
        {
            return await _service.GetTypes();
        }

    }
}
