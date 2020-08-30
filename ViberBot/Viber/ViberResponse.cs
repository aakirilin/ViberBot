using System.Text.Json.Serialization;

namespace ViberBot.Viber
{
    public class ViberResponse
    {
        [JsonPropertyName("status")]
        public int status { get; set; }

        [JsonPropertyName("status_message")]
        public string statusMessage { get; set; }

        [JsonPropertyName("message_token")]
        public string messageToken { get; set; }

        [JsonPropertyName("user")]
        public object data { get; set; }
    }
}
