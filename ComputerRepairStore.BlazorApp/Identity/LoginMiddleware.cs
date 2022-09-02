using ComputerRepairStore.Domain.Entities.Input;
using ComputerRepairStore.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputerRepairStore.BlazorApp.Identity
{
    public class LoginMiddleware
    {
        private static IDictionary<Guid, LoginInputModel> Logins { get; set; }
            = new ConcurrentDictionary<Guid, LoginInputModel>();

        public static Guid AddLoginRequest(LoginInputModel model)
        {
            Guid guid = Guid.NewGuid();
            Logins[guid] = model;

            return guid;
        }

        private readonly RequestDelegate _next;

        public LoginMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IUserService service)
        {
            if (context.Request.Path == "/_identity/login" && context.Request.Query.ContainsKey("key"))
            {
                var key = Guid.Parse(context.Request.Query["key"]);
                var redirectTo = context.Request.Query.ContainsKey("endpoint") ? (string)context.Request.Query["endpoint"] : "/";

                try
                {
                    await service.Login(Logins[key]);
                    context.Response.Redirect(redirectTo);
                }
                finally
                {
                    Logins.Remove(key);
                }

                return;
            }
            else
            {
                await _next.Invoke(context);
            }
        }
    }
}
