using System.Text.Json.Serialization;

namespace ViberBot.Viber
{
    public class Sender
    {
        [JsonPropertyName("id")]
        public string id { get; set; }

        [JsonPropertyName("name")]
        public string name { get; set; }

        [JsonPropertyName("avatar")]
        public string avatar { get; set; }

        [JsonPropertyName("country")]
        public string country { get; set; }

        [JsonPropertyName("language")]
        public string language { get; set; }

        [JsonPropertyName("api_version")]
        public int apiVersion { get; } = 1;

        public static Sender ThisBot
        {
            get
            {
                var sender = new Sender();
                sender.name = BotSettings.Name;
                sender.avatar = BotSettings.Avatar;
                return sender;
            }
        }
    }

}
