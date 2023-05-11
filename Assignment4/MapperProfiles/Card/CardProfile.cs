using Assignment4.Controllers.Card.response;
using AutoMapper;

namespace Assignment4.MapperProfiles.Card
{
    public class CardProfile : Profile
    {
        public CardProfile()
        {
            CreateMap<Hearthstone.DataAccess.Models.Card, CardResponse>();
        }
    }
}
