using System.Linq;
using System.Threading.Tasks;

namespace ComputerRepairStore.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        Task<T> GetById(int id);
        Task<T> Create(T entity);
        Task Delete(int id);
        Task Update(T entity);
    }
}
