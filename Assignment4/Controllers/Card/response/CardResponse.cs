namespace Assignment4.Controllers.Card.response
{
    public class CardResponse
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Class { get; set; } = null!;
        public string Type { get; set; } = null!;
        public string Set { get; set; } = null!;
        public string? SpellSchoolId { get; set; }
        public string Rarity { get; set; } = null!;
        public int? Health { get; set; }
        public int? Attack { get; set; }
        public int ManaCost { get; set; }
        public string Artist { get; set; } = null!;
        public string Text { get; set; } = null!;
        public string FlavorText { get; set; } = null!;
    }
}
