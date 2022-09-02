using ComputerRepairStore.Domain.Entities;
using ComputerRepairStore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerRepairStore.Business.Service
{
    public class RepairOrderService : IRepairOrderService
    {
        private readonly IRepository<RepairOrder> repository;

        public RepairOrderService(IRepository<RepairOrder> repository)
        {
            this.repository = repository;
        }

        public async Task Create(RepairOrder order)
        {
            if (order.Customer == null)
                throw new ArgumentException("Customer is missing from the order");

            if (order.Description == null)
                throw new ArgumentException("Description is missing from the order");

            if (order.ShortDescription == null)
                throw new ArgumentException("Short Description is missing from the order");

            await repository.Create(order);
        }

        public async Task Update(RepairOrder order)
        {
            if (order.Customer == null)
                throw new ArgumentException("Customer is missing from the order");

            await repository.Update(order);
        }

        public async Task Delete(int id)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id));

            await repository.Delete(id);
        }

        public IEnumerable<RepairOrder> GetAll(User user)
        {
            if (user.UserType != UserType.Customer)
            {
                return repository.GetAll().Where(x => x.Deleted == false).AsEnumerable();
            }
            else
            {
                return repository.GetAll().Where(x => x.Customer == user && x.Deleted == false).AsEnumerable();
            }
        }

        public async Task<RepairOrder> GetById(int id)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id));

            return await repository.GetById(id);
        }

        public List<RepairOrder> Search(string query, User user)
        {
            return GetAll(user)
                .Where(x => (
                    x.Customer.UserName.Contains(query, StringComparison.CurrentCultureIgnoreCase) ||
                    (x.Employee != null && x.Employee.UserName.Contains(query, StringComparison.CurrentCultureIgnoreCase)) ||
                    x.Description.Contains(query, StringComparison.CurrentCultureIgnoreCase) ||
                    x.ShortDescription.Contains(query, StringComparison.CurrentCultureIgnoreCase) ||
                    x.RegistrationDate.ToString().Contains(query))).ToList();
        }

        public List<RepairOrder> OrderBy(List<RepairOrder> orders, SortBy sort)
        {
            switch (sort)
            {
                case SortBy.Order:
                    orders = orders.OrderBy(x => x.ShortDescription).ToList();
                    break;

                case SortBy.RegistrationDate:
                    orders = orders.OrderBy(x => x.RegistrationDate).ToList();
                    break;

                case SortBy.RepairStatus:
                    orders = orders.OrderBy(x => x.RepairStatus).ToList();
                    break;

                case SortBy.PlannedFinishDate:
                    orders = orders.OrderBy(x => x.PlannedFinishDate).ToList();
                    break;

                case SortBy.Customer:
                    orders = orders.OrderBy(x => x.Customer.UserName).ToList();
                    break;

                case SortBy.Employee:
                    orders = orders.OrderBy(x => x.Employee?.UserName).ToList();
                    break;
            }

            return orders;
        }
    }
}
