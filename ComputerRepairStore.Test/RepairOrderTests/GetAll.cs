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
    public class GetAll
    {
        readonly RepairOrderService service;
        readonly Mock<IRepository<RepairOrder>> mockRepository;
        readonly User user;

        public GetAll()
        {
            mockRepository = new();
            service = new(mockRepository.Object);
            user = new();
        }

        [Theory]
        [InlineData(UserType.Administrator)]
        [InlineData(UserType.Employee)]
        public void Should_ReturnAllOrders_When_UserIsEmployeeOrAdmin(UserType userType)
        {
            // Arrange
            mockRepository.Setup(x => x.GetAll()).Returns(new List<RepairOrder>()
            {
                new RepairOrder { Id = 1, Customer = new User(), RegistrationDate = DateTime.Now},
                new RepairOrder { Id = 1, Customer = new User(), RegistrationDate = DateTime.Now},
                new RepairOrder { Id = 1, Customer = new User(), RegistrationDate = DateTime.Now}
            }.AsQueryable());

            user.UserType = userType;

            // Act
            var orders = service.GetAll(user);
            var list = orders.ToList();

            // Assert
            list.Count.Should().Be(3);
        }

        [Fact]
        public void Should_OnlyReturnCustomerOrders_When_UserIsCustomer()
        {
            // Arrange
            user.UserType = UserType.Customer;

            mockRepository.Setup(x => x.GetAll()).Returns(new List<RepairOrder>()
            {
                new RepairOrder { Id = 1, Customer = user, RegistrationDate = DateTime.Now},
                new RepairOrder { Id = 1, Customer = new User(), RegistrationDate = DateTime.Now},
                new RepairOrder { Id = 1, Customer = user, RegistrationDate = DateTime.Now}
            }.AsQueryable());

            // Act
            var orders = service.GetAll(user);
            var list = orders.ToList();

            // Assert
            list.Count.Should().Be(2);
        }
    }
}
