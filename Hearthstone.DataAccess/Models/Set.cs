using System.Text.Json.Serialization;

namespace Hearthstone.DataAccess.Models
{
    public class Set
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Type { get; set; } = null!;

        [JsonPropertyName("collectibleCount")]
        public int CardCount { get; set; }
    }
}
