using Assignment4.Controllers.Card.response;
using AutoMapper;
using Hearthstone.DataAccess.MongoDbServices;
using Microsoft.AspNetCore.Mvc;

namespace Assignment4.Controllers.Card
{
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly CardService _cardService;
        private readonly ClassService _classService;
        private readonly TypeService _typeService;
        private readonly SetsService _setsService;
        private readonly RarityService _rarityService;

        private readonly IMapper _mapper;
        private readonly ILogger<CardController> _logger;

        public CardController(
            CardService cardService,
            ClassService classService,
            TypeService typeService,
            SetsService setsService,
            RarityService rarityService,
            IMapper mapper,
            ILogger<CardController> logger)
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
        /// Gets Cards with query parameters
        /// </summary>
        /// <response code="200">Returns Cards</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
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

            var classes = await _classService.GetClasses();
            var types = await _typeService.GetTypes();
            var sets = await _setsService.GetSets();
            var rarities = await _rarityService.GetRarities();

            var cardsResponse = cards.Select(card =>
            {
                var currentCard = _mapper.Map<CardResponse>(card);

                currentCard.Class = classes.FirstOrDefault(c => c.Id == card.ClassId)?.Name!;
                currentCard.Type = types.FirstOrDefault(t => t.Id == card.TypeId)?.Name!;
                currentCard.Set = sets.FirstOrDefault(s => s.Id == card.SetId)?.Name!;
                currentCard.Rarity = rarities.FirstOrDefault(r => r.Id == card.RarityId)?.Name!;

                return currentCard;
            }).ToList();

            _logger.LogInformation($"GetCardsWithParameters request completed. {cards.Count} cards found.");

            return Ok(cardsResponse);
        }
    }
}
