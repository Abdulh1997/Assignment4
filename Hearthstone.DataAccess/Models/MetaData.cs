namespace Hearthstone.DataAccess.Models
{
    public class MetaData
    { 
        public List<Set> Sets { get; set; } = null!;
        public List<Rarity> Rarities { get; set; } = null!;
        public List<Class> Classes { get; set; } = null!;
        public List<CardType> Types { get; set; } = null!;
    } 
}
