using ComputerRepairStore.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputerRepairStore.Domain.Interfaces
{
    public interface IRepairOrderService
    {
        IEnumerable<RepairOrder> GetAll(User user);

        Task<RepairOrder> GetById(int id);

        List<RepairOrder> Search(string query, User user);

        Task Create(RepairOrder order);

        Task Update(RepairOrder order);

        Task Delete(int id);

        List<RepairOrder> OrderBy(List<RepairOrder> orders, SortBy sort);
    }
}
