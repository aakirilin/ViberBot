using System.IO;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ViberBot.Viber
{
    public class Utils
    {
        public static string get_user_details => @"https://chatapi.viber.com/pa/get_user_details";
        public static string send_message => @"https://chatapi.viber.com/pa/send_message";
        public static string set_webhook => @"https://chatapi.viber.com/pa/set_webhook";

        public static string Serialize<T>(object message)
        {
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.IgnoreNullValues = true;
            return JsonSerializer.Serialize<T>((T)message, options);
        }

        public static string SendRequest<T>(string url, object message)
        {
            var json = Serialize<T>(message);
            byte[] data = Encoding.UTF8.GetBytes(json);
            WebRequest request = WebRequest.Create(url);
            request.Headers.Add("X-Viber-Auth-Token", BotSettings.Token);
            request.Method = "POST";
            request.ContentType = "application/json; charset=utf-8";
            request.ContentLength = data.Length;
            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
            string responseContent = null;
            using (WebResponse response = request.GetResponse())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader sr99 = new StreamReader(stream))
                    {
                        responseContent = sr99.ReadToEnd();
                    }
                }
            }
            return responseContent;
        }

        public static string SendTextMessage(string receiver, string text)
        {
            var message = new ViberMessage(receiver, text);
            var response = Utils.SendRequest<ViberMessage>(Utils.send_message, message);
            return response;
        }

        public static string SendTextMessageWithButtons(string receiver, string text, params ViberButton[] buttons)
        {
            var message = new ViberMessage(receiver, text, buttons);
            var response = Utils.SendRequest<ViberMessage>(Utils.send_message, message);
            return response;
        }

        public static string SetWebHook()
        {
            var request = WebHookRequest.Create(BotSettings.WebHookUrl);
            var response = Utils.SendRequest<WebHookRequest>(Utils.set_webhook, request);
            return response;
        }

        public static Task<string> SetWebHookAsync()
        {
            return Task<string>.Factory.StartNew(SetWebHook);
        }

        public static string RemoveWebHook()
        {
            var request = WebHookRequest.Create("");
            var response = Utils.SendRequest<WebHookRequest>(Utils.set_webhook, request);
            return response;
        }

        public static Task<string> RemoveWebHookAsync()
        {
            return Task<string>.Factory.StartNew(RemoveWebHook);
        }
    }
}
