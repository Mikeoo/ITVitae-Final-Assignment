using ComputerRepairStore.Business.Context;
using ComputerRepairStore.Domain.Entities;
using ComputerRepairStore.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerRepairStore.Business.Repository
{
    [ExcludeFromCodeCoverage]
    public class RepairOrderRepository : IRepository<RepairOrder>
    {
        private readonly DataContext context;

        public RepairOrderRepository(DataContext context)
        {
            this.context = context;
        }

        public async Task<RepairOrder> Create(RepairOrder entity)
        {
            await context.RepairOrders.AddAsync(entity);
            await SaveChanges();

            return entity;
        }

        public async Task Delete(int id)
        {
            var toDelete = await GetById(id);
            toDelete.Deleted = true;

            await Update(toDelete);
        }

        public IQueryable<RepairOrder> GetAll()
        {
            return context.RepairOrders.AsQueryable();
        }

        public async Task<RepairOrder> GetById(int id)
        {
            return await GetAll().SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task Update(RepairOrder entity)
        {
            context.Update(entity);
            await SaveChanges();
        }

        private async Task SaveChanges()
        {
            await context.SaveChangesAsync();
        }
    }
}
