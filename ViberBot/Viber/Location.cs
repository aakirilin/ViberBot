using System.Text.Json.Serialization;

namespace ViberBot.Viber
{
    public class Location
    {
        [JsonPropertyName("lat")]
        public double lat { get; set; }

        [JsonPropertyName("lon")]
        public double lon { get; set; }
    }
}
