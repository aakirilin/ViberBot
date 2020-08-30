using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using ViberBot.Data;
using ViberBot.Filters;
using ViberBot.Models;
using ViberBot.Viber;

namespace ViberBot.Controllers
{
    [Route("api"), ApiController]
    public class ApiController : ControllerBase
    {
        private readonly DatabaseContext context;

        public ApiController(DatabaseContext context)
        {
            this.context = context;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(User user)
        {
            var findUser = await this.context
                .users.FirstOrDefaultAsync(u => u.login.Equals(user.login));
            if (findUser == null)
                return new Response($"Пользователь {user.login} не найден.", false);
            if (!findUser.EqualPassword(user.password))
                return new Response($"Не верный пароль", false);

            findUser.accsesToken = Guid.NewGuid().ToString();
            await this.context.SaveChangesAsync();

            return new Response(findUser.accsesToken, true);
        }

        [HttpPost("setWebHook"), AuthorizationFilter("admin")]
        public async Task<IActionResult> SetWebHook()
        {
            var response = await Utils.SetWebHookAsync();
            context.logs.Add(new Log("SetWebHook", response));
            await context.SaveChangesAsync();
            return new Response(response, true, "");
        }

        [HttpPost("removeWebHook"), AuthorizationFilter("admin")]
        public async Task<IActionResult> RemoveWebHook()
        {
            var response = await Utils.RemoveWebHookAsync();
            context.logs.Add(new Log("RemoveWebHook", response));
            await context.SaveChangesAsync();
            return new Response(response, true, "");
        }
    }
}