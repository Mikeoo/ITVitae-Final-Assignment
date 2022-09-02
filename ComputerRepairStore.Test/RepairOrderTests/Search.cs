using ComputerRepairStore.Business.Service;
using ComputerRepairStore.Domain.Entities;
using ComputerRepairStore.Domain.Interfaces;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace RepairOrderTests
{
    public class Search
    {
        readonly RepairOrderService service;
        readonly Mock<IRepository<RepairOrder>> mockRepository;
        readonly User user;

        public Search()
        {
            mockRepository = new();
            service = new(mockRepository.Object);
            user = new();
        }

        [Fact]
        public void Should_ReturnCorrectPhone_When_ValidSearchIsGiven()
        {
            // Arrange
            string query = "Test";

            user.UserType = UserType.Employee;

            var orders = new List<RepairOrder>()
            {
                new RepairOrder { Id = 1, Customer = new(){ UserName = query }, Employee =new User(){UserName = string.Empty}, RegistrationDate = DateTime.Now},
                new RepairOrder { Id = 2, Customer = new(){UserName = string.Empty}, Employee = new User(){ UserName = query }, RegistrationDate = DateTime.Now},
                new RepairOrder {Id = 3, Customer = new(){UserName = string.Empty}, Employee = new(){UserName = string.Empty}, RegistrationDate = DateTime.Now, Description = query},
                new RepairOrder {Id = 3, Customer = new(){UserName = string.Empty}, Employee = new(){UserName = string.Empty}, RegistrationDate = DateTime.Now, Description = string.Empty, ShortDescription = query}
            };

            mockRepository.Setup(x => x.GetAll()).Returns(orders.AsQueryable());

            // Act
            var search = service.Search(query, user);
            var list = search.ToList();

            // Assert
            list.Count.Should().Be(4);
            list[0].Id.Should().Be(1);
        }
    }
}
