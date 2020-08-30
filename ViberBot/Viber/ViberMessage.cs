using System.Text.Json.Serialization;

namespace ViberBot.Viber
{
    public class ViberMessage
    {
        [JsonPropertyName("receiver")]
        public string receiver { get; protected set; }

        [JsonPropertyName("min_api_version")]
        public int minApiVersion => 6;

        [JsonPropertyName("sender")]
        public Sender sender { get; protected set; }

        [JsonPropertyName("type")]
        public string type { get; protected set; }

        [JsonPropertyName("text")]
        public string text { get; protected set; }

        [JsonPropertyName("keyboard")]
        public ViberKeyboard keyboard { get; protected set; }

        public ViberMessage(string type)
        {
            this.type = type;
            this.sender = Sender.ThisBot;
        }

        public ViberMessage(string receiver, string text) : this("text")
        {
            this.receiver = receiver;
            this.text = text;
        }

        public ViberMessage(string receiver, string text, params ViberButton[] buttons) : this(receiver, text)
        {
            this.keyboard = new ViberKeyboard();
            this.keyboard.buttons = buttons;
        }
    }

}
