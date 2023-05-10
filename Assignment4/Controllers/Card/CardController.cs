using Assignment4.Controllers.Card.response;
using AutoMapper;
using Hearthstone.DataAccess.Service;
using Microsoft.AspNetCore.Mvc;

namespace Assignment4.Controllers.Card
{
    [ApiController]
    [Route("api/[controller]")]
    public class CardController : ControllerBase
    {
        private readonly CardService _cardService;
        private readonly ClassService _classService;
        private readonly TypeService _typeService;
        private readonly SetsService _setsService;
        private readonly RarityService _rarityService;

        private readonly IMapper _mapper;
        private readonly ILogger<ClassService> _logger;


        public CardController(
            CardService cardService,
            ClassService classService,
            TypeService typeService,
            SetsService setsService,
            RarityService rarityService,
            IMapper mapper,
            ILogger<ClassService> logger)
        {
            _cardService = cardService;
            _classService = classService;
            _typeService = typeService;
            _setsService = setsService;
            _rarityService = rarityService;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Gets all Cards
        /// </summary>
        /// <response code="200">Returns all cards</response>
        /// <response code="404">No cards found</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("cards")]
        public async Task<ActionResult<IReadOnlyList<Hearthstone.DataAccess.Models.Card>>> GetCardsWithParameters(
            int? typeId = null,
            int? setId = null,
            int? classId = null,
            int? rarityId = null,
            string? artist = null,
            int? page = null)
        {

            _logger.LogInformation("GetCardsWithParameters request received.");

            var cards = await _cardService.GetCards(setId, classId, rarityId, typeId, artist, page);

            if (cards.Count <= 0)
            {
                return NotFound();
            }

            var classes = await _classService.GetClasses();

            var types = await _typeService.GetTypes();

            var sets = await _setsService.GetSets();

            var rarity = await _rarityService.GetRarities();
            
            var cardsResponse = new List<CardResponse>();

            foreach (var card in cards)
            {
                var currentCard = _mapper.Map<CardResponse>(card);

                foreach (var @class in classes)
                {
                    if (card.ClassId == @class.Id)
                    {
                        currentCard.Class = @class.Name;
                    }
                }

                foreach (var cardType in types)
                {
                    if (card.TypeId == cardType.Id)
                    {
                        currentCard.Type == cardType.Name;
                    }
                }

                cardsResponse.Add(currentCard);
            }

            _logger.LogInformation($"GetClasses request completed. {cards.Count} classes found.");

            return Ok(cardsResponse);
        }
    }
}
