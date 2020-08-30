using System.Text.Json.Serialization;

namespace ViberBot.Viber
{
    public class ViberCallbackEventMessage
    {
        [JsonPropertyName("type")]
        public string type { get; set; }

        [JsonPropertyName("text")]
        public string text { get; set; }

        [JsonPropertyName("media")]
        public string media { get; set; }

        [JsonPropertyName("location")]
        public Location location { get; set; }

        [JsonPropertyName("tracking_data")]
        public string trackingData { get; set; }

        [JsonPropertyName("contact")]
        public string contact { get; set; }

        [JsonPropertyName("file_name")]
        public string fileName { get; set; }

        [JsonPropertyName("file_size")]
        public string fileSize { get; set; }

        [JsonPropertyName("duration")]
        public string duration { get; set; }

        [JsonPropertyName("sticker_id")]
        public string stickerId { get; set; }
    }
}
