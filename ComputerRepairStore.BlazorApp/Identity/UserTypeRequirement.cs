using ComputerRepairStore.Domain.Entities;
using Microsoft.AspNetCore.Authorization;

namespace ComputerRepairStore.BlazorApp.Identity
{
    public class UserTypeRequirement : IAuthorizationRequirement
    {
        public UserTypeRequirement(UserType userType)
        {
            UserType = userType;
        }

        public UserType UserType { get; }
    }
}
