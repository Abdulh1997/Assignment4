using System.Text.Json.Serialization;

namespace Assignment4.Modeles
{
    public class Set
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Type { get; set; }
        [JsonPropertyName("collectibleCount")]
        public int CardCount { get; set; }

    
    }
}
