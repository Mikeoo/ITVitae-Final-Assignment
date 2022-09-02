using ComputerRepairStore.Domain.Entities;
using ComputerRepairStore.Domain.Entities.Input;
using System.Threading.Tasks;

namespace ComputerRepairStore.Domain.Interfaces
{
    public interface IUserService
    {
        public Task<User> Login(LoginInputModel model);
        public Task<bool> IsValidLogin(LoginInputModel model);
        public Task Logout();
        public Task<User> GetCurrentUser();
    }
}
