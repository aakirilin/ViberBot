using System.Text.Json.Serialization;

namespace ViberBot.Viber
{
    public class ViberButton
    {
        [JsonPropertyName("ActionType")]
        public string actionType { get; set; } = "reply";

        [JsonPropertyName("ActionBody")]
        public string actionBody { get; private set; }

        [JsonPropertyName("Text")]
        public string text { get; private set; }

        [JsonPropertyName("TextSize")]
        public string textSize { get; set; } = "regular";

        public ViberButton(string actionBody, string text)
        {
            this.actionBody = actionBody;
            this.text = text;
        }
    }
}
