using System.Text.Json.Serialization;

namespace ViberBot.Viber
{
    public class ViberCallbackEvent
    {
        [JsonPropertyName("event")]
        public string typeCallback { get; set; }

        [JsonPropertyName("timestamp")]
        public long timestamp { get; set; }

        [JsonPropertyName("message_token")]
        public long messageToken { get; set; }

        [JsonPropertyName("type")]
        public string type { get; set; }

        [JsonPropertyName("sender")]
        public Sender sender { get; set; }

        [JsonPropertyName("user")]
        public Sender user { get; set; }

        [JsonPropertyName("message")]
        public ViberCallbackEventMessage message { get; set; }

        public string senderId
        {
            get
            {
                if (sender != null && sender.id != null)
                {
                    return sender.id;
                }
                if (user != null && user.id != null)
                {
                    return user.id;
                }
                return null;
            }
        }
    }
}
