using ComputerRepairStore.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ComputerRepairStore.BlazorApp.Identity
{
    public class LogoutMiddleware
    {
        private readonly RequestDelegate _next;

        public LogoutMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IUserService service)
        {
            if (context.Request.Path == "/_identity/logout")
            {
                var redirectTo = context.Request.Query.ContainsKey("endpoint") ? (string)context.Request.Query["endpoint"] : "/";

                await service.Logout();
                context.Response.Redirect(redirectTo);
            }
            else
            {
                await _next.Invoke(context);
            }
        }
    }
}
