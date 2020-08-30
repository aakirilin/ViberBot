using System.Text.Json.Serialization;

namespace ViberBot.Viber
{
    public class ViberKeyboard
    {
        [JsonPropertyName("Type")]
        public string type { get; set; } = "keyboard";

        [JsonPropertyName("DefaultHeight")]
        public bool defaultHeight { get; set; } = true;

        [JsonPropertyName("Buttons")]
        public ViberButton[] buttons { get; set; }
    }
}
