using System.Text.Json.Serialization;

namespace ViberBot.Viber
{
    public abstract class Message
    {
        [JsonPropertyName("receiver")]
        public string receiver { get; protected set; }

        [JsonPropertyName("min_api_version")]
        public int minApiVersion => 6;

        [JsonPropertyName("sender")]
        public Sender sender { get; protected set; }

        [JsonPropertyName("type")]
        public string type { get; protected set; }

        [JsonPropertyName("keyboard")]
        public ViberKeyboard keyboard { get; protected set; }

        public Message(string type)
        {
            this.type = type;
            this.sender = Sender.ThisBot;
        }
    }
}
