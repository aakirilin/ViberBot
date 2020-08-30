using System.Text.Json.Serialization;

namespace ViberBot.Viber
{
    public class UserData
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
        public string languege { get; set; }

        [JsonPropertyName("primary_device_os")]
        public string primaryDeviceOs { get; set; }

        [JsonPropertyName("api_version")]
        public string apiVerson { get; set; }

        [JsonPropertyName("viber_version")]
        public string viberVersion { get; set; }

        [JsonPropertyName("mcc")]
        public int mcc { get; set; }

        [JsonPropertyName("mnc")]
        public int mnc { get; set; }

        [JsonPropertyName("device_type")]
        public string DeviceType { get; set; }
    }
}
