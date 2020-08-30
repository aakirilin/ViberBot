using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using ViberBot.Data;
using ViberBot.Models;
using ViberBot.Viber;

namespace ViberBot.Controllers
{
    [Route("ViberWebHook")]
    [ApiController]
    public class ViberWebHookController : ControllerBase
    {
        private readonly DatabaseContext context;

        public ViberWebHookController(DatabaseContext context)
        {
            this.context = context;
        }

        private string onMessage(ViberCallbackEvent callbackEvent)
        {
            var command = Bot.instanse.GetCommand(callbackEvent.message.text);
            if (command != null)
            {
                return command.Execute(callbackEvent, context);
            }
            else
            {
                context.logs.Add(new Log("WebHook", $"Команда {command} не найдена."));
                context.SaveChanges();
                return "Команда не найдена";
            }
        }

        private string onConversationStarted(ViberCallbackEvent callbackEvent)
        {
            var command = new HelloCommand();
            return command.Execute(callbackEvent, context);
        }

        private Task ExecuteCommand(string data)
        {
            return Task.Factory.StartNew(() =>
            {
                try
                {
                    ViberCallbackEvent callbackEvent = JsonSerializer.Deserialize<ViberCallbackEvent>(data);
                    if (callbackEvent != null)
                    {
                        var response = "";
                        switch (callbackEvent.typeCallback.ToLower())
                        {
                            case "message": response = onMessage(callbackEvent); break;
                            case "conversation_started": response = onConversationStarted(callbackEvent); break;
                        }
                    }
                }
                catch (Exception e)
                {
                    context.logs.Add(new Log(e.Message, e.StackTrace));
                    context.SaveChanges();
                }
            });
        }

        public async Task<IActionResult> Post()
        {
            if (Request != null && Request.Body != null)
            {
                string data = null;
                using (Stream stream = Request.Body)
                {
                    using (StreamReader sr99 = new StreamReader(stream))
                    {
                        data = await sr99.ReadToEndAsync();
                    }
                }
                await ExecuteCommand(data);
            }

            return new OkResult();
        }
    }
}