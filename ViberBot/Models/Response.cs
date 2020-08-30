using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Threading.Tasks;

namespace ViberBot.Models
{
    public class Response : IActionResult
    {
        public string message { get; private set; }

        public bool success { get; private set; }

        public string redirect { get; private set; }

        public Response(string message, bool success)
        {
            this.message = message;
            this.success = success;
        }

        public Response(
            string message,
            bool success,
            string redirect) : this(message, success)
        {
            this.redirect = redirect;
        }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            var json = JsonSerializer.Serialize<Response>(this);
            await context.HttpContext.Response.WriteAsync(json);
        }
    }
}