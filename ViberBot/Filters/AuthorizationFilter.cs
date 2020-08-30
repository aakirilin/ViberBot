using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using ViberBot.Data;
using ViberBot.Models;

namespace ViberBot.Filters
{
    public class AuthorizationFilter : Attribute, IAsyncAuthorizationFilter
    {
        private string role { get; set; }

        public AuthorizationFilter(string role)
        {
            this.role = role;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            if (context.HttpContext.Request.Headers.ContainsKey("Authorization"))
            {
                var contextDB = DatabaseContextFactory.getContext;
                var accsesToken = context.HttpContext.Request.Headers["Authorization"];
                var user = await contextDB.users
                    .FirstOrDefaultAsync(u => u.accsesToken.Equals(accsesToken));
                if (user != null && user.role.ToString().Equals(this.role))
                {
                    return;
                }
            }

            var response = new Response("Доступно только для авторизованных пользователей.", false);

            context.Result = response;
        }
    }
}
