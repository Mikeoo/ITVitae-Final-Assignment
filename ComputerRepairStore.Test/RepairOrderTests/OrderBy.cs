using ComputerRepairStore.Business.Service;
using ComputerRepairStore.Domain.Entities;
using ComputerRepairStore.Domain.Interfaces;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace RepairOrderTests
{
    public class OrderBy
    {
        readonly RepairOrderService service;
        readonly Mock<IRepository<RepairOrder>> mockRepository;
        private List<RepairOrder> orders;
        private readonly DateTime now;

        public OrderBy()
        {
            mockRepository = new();
            service = new(mockRepository.Object);

            now = DateTime.Now;

            orders = new List<RepairOrder>()
            {
                new RepairOrder()
                {
                    RegistrationDate = DateTime.MaxValue,
                    RepairStatus = RepairStatus.WaitingForParts,
                    PlannedFinishDate = DateTime.MaxValue,
                    Customer = new User() { UserName = "c"},
                    Employee = new User() { UserName = "c"}
                },
                new RepairOrder()
                {
                    RegistrationDate = now,
                    RepairStatus = RepairStatus.Received,
                    PlannedFinishDate = DateTime.MaxValue,
                    Customer = new User() { UserName = "b"},
                    Employee = new User() { UserName = "b"}
                },
                new RepairOrder()
                {
                    RegistrationDate = DateTime.MinValue,
                    RepairStatus = RepairStatus.InProcess,
                    PlannedFinishDate = DateTime.MinValue,
                    Customer = new User() { UserName = "e"},
                    Employee = new User() { UserName = "e"}
                },
                new RepairOrder()
                {
                    RegistrationDate = DateTime.MaxValue,
                    RepairStatus = RepairStatus.Cancelled,
                    PlannedFinishDate = now,
                    Customer = new User() { UserName = "d"},
                    Employee = new User() { UserName = "d"}
                },
                new RepairOrder()
                {
                    RegistrationDate = DateTime.MaxValue,
                    RepairStatus = RepairStatus.Finished,
                    PlannedFinishDate = DateTime.MaxValue,
                    Customer = new User() { UserName = "a"},
                    Employee = new User() { UserName = "a"}
                },
            };
        }

        [Fact]
        public void Should_OrderByRegistrationDate_When_EnumIsRegistrationDate()
        {
            // Act
            orders = service.OrderBy(orders, SortBy.RegistrationDate);

            // Assert
            orders[0].RegistrationDate.Should().Be(DateTime.MinValue);
            orders[1].RegistrationDate.Should().Be(now);
        }

        [Fact]
        public void Should_OrderByRepairStatus_When_EnumIsRepairStatus()
        {
            // Act
            orders = service.OrderBy(orders, SortBy.RepairStatus);

            // Assert
            orders[0].RepairStatus.Should().Be(RepairStatus.Received);
            orders[1].RepairStatus.Should().Be(RepairStatus.WaitingForParts);
            orders[2].RepairStatus.Should().Be(RepairStatus.InProcess);
            orders[3].RepairStatus.Should().Be(RepairStatus.Finished);
            orders[4].RepairStatus.Should().Be(RepairStatus.Cancelled);
        }

        [Fact]
        public void Should_OrderByPlannedFinishDate_When_EnumIsPlannedFinishDate()
        {
            // Act
            orders = service.OrderBy(orders, SortBy.PlannedFinishDate);

            // Assert
            orders[0].PlannedFinishDate.Should().Be(DateTime.MinValue);
            orders[1].PlannedFinishDate.Should().Be(now);
        }

        [Fact]
        public void Should_OrderByCustomer_When_EnumIsCustomer()
        {
            // Act
            orders = service.OrderBy(orders, SortBy.Customer);

            // Assert
            orders[0].Customer.UserName.Should().Be("a");
            orders[1].Customer.UserName.Should().Be("b");
            orders[2].Customer.UserName.Should().Be("c");
            orders[3].Customer.UserName.Should().Be("d");
            orders[4].Customer.UserName.Should().Be("e");
        }

        [Fact]
        public void Should_OrderByEmployee_When_EnumIsEmployee()
        {
            // Act
            orders = service.OrderBy(orders, SortBy.Employee);

            // Assert
            orders[0].Employee.UserName.Should().Be("a");
            orders[1].Employee.UserName.Should().Be("b");
            orders[2].Employee.UserName.Should().Be("c");
            orders[3].Employee.UserName.Should().Be("d");
            orders[4].Employee.UserName.Should().Be("e");
        }
    }

}
