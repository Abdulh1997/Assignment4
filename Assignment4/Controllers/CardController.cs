using Assignment4.Modeles;
using Assignment4.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Assignment4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly CardService _service;
        public IList<CardType> Cards { get; set; } = new List<CardType>();

        public CardController (CardService cardService)
        {
            _service= cardService;
        }


        [HttpGet("AllCards")]
        public async Task<IList<Card>> GetAllCards()
        {
            return await _service.GetAllCards();
        }


        // GET api/<CardController>/5
        [HttpGet("cards")]
        public async Task<List<Card>> Get(int? typeid = null, int? setid = null, int? classid = null, int? rarityid = null, string? artist = null, int? page = null)
        {
           return (List<Card>)await _service.Search(setid, classid, rarityid, typeid, artist, page);
        }
    }
}
