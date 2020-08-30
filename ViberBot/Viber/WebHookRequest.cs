using System.Text.Json.Serialization;

namespace ViberBot.Viber
{
    public class WebHookRequest
    {
        [JsonPropertyName("url")]
        public string url { get; set; }

        [JsonPropertyName("event_types")]
        public string[] eventTypes { get; set; }

        [JsonPropertyName("send_name")]
        public bool sendName { get; set; }

        [JsonPropertyName("send_photo")]
        public bool sendPhoto { get; set; }

        public static WebHookRequest Create(string webHokeAddres)
        {
            var webHook = new WebHookRequest();
            webHook.url = webHokeAddres;
            webHook.eventTypes = new string[]
            {
                    "delivered",
                    "seen",
                    "failed",
                    "subscribed",
                    "unsubscribed",
                    "conversation_started"
            };
            webHook.sendName = true;
            webHook.sendPhoto = true;
            return webHook;
        }
    }
}
