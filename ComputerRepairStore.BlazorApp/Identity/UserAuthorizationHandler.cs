using ComputerRepairStore.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace ComputerRepairStore.BlazorApp.Identity
{
    public class UserAuthorizationHandler : AuthorizationHandler<UserTypeRequirement>
    {
        private readonly UserManager<User> _userManager;

        public UserAuthorizationHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, UserTypeRequirement requirement)
        {
            var user = await _userManager.GetUserAsync(context.User);
            if (user == null) return;

            if (user.UserType >= requirement.UserType)
            {
                context.Succeed(requirement);
            }
        }
    }
}
