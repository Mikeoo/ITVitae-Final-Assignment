using ComputerRepairStore.Domain.Entities;
using ComputerRepairStore.Domain.Entities.Input;
using ComputerRepairStore.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace ComputerRepairStore.Business.Service
{
    [ExcludeFromCodeCoverage]
    public class UserService : IUserService
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public UserService(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<bool> IsValidLogin(LoginInputModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
                throw new ArgumentException("User not found");
            if (!user.EmailConfirmed)
                throw new ApplicationException("User did not confirm email");

            var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
            return result.Succeeded;
        }

        public async Task<User> Login(LoginInputModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
                throw new ArgumentException("User not found");
            if (!user.EmailConfirmed)
                throw new ApplicationException("User did not confirm email");

            await _signInManager.PasswordSignInAsync(user, model.Password, true, false);
            return user;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<User> GetCurrentUser()
        {
            return await _userManager.GetUserAsync(_signInManager.Context.User);
        }
    }
}
