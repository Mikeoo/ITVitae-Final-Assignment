using ComputerRepairStore.Business.Service;
using ComputerRepairStore.Domain.Entities;
using ComputerRepairStore.Domain.Interfaces;
using FluentAssertions;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace RepairOrderTests
{
    public class Create
    {
        readonly RepairOrderService service;
        readonly Mock<IRepository<RepairOrder>> mockRepository;

        public Create()
        {
            mockRepository = new();
            service = new(mockRepository.Object);
        }

        [Fact]
        public async Task Should_ExecuteCreateOnce()
        {
            // Arrange
            var order = new RepairOrder { Id = 1, Customer = new User(), Description = "", ShortDescription = "", RegistrationDate = DateTime.Now };

            // Act
            await service.Create(order);

            // Assert
            mockRepository.Verify(x => x.Create(It.IsAny<RepairOrder>()), Times.Once);
        }

        [Fact]
        public async Task Should_ThrowArgumentException_When_CustomerIsNull()
        {
            // Arrange
            var order = new RepairOrder() { Id = 1 };

            // Act
            Func<Task> action = async () => await service.Create(order);

            // Assert
            await action.Should().ThrowAsync<ArgumentException>().WithMessage("Customer is missing from the order");
        }

        [Fact]
        public async Task Should_ThrowArgumentException_When_DescriptionIsNull()
        {
            // Arrange
            var order = new RepairOrder() { Id = 1, Customer = new() };

            // Act
            Func<Task> action = async () => await service.Create(order);

            // Assert
            await action.Should().ThrowAsync<ArgumentException>().WithMessage("Description is missing from the order");
        }

        [Fact]
        public async Task Should_ThrowArgumentException_When_ShortDescriptionIsNull()
        {
            // Arrange
            var order = new RepairOrder() { Id = 1, Customer = new(), Description = "" };

            // Act
            Func<Task> action = async () => await service.Create(order);

            // Assert
            await action.Should().ThrowAsync<ArgumentException>().WithMessage("Short Description is missing from the order");
        }
    }
}
