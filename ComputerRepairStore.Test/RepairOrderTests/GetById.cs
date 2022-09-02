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
    public class GetById
    {
        readonly RepairOrderService service;
        readonly Mock<IRepository<RepairOrder>> mockRepository;

        public GetById()
        {
            mockRepository = new();
            service = new(mockRepository.Object);
        }

        [Fact]
        public async Task Should_ReturnSingleOrder()
        {
            // Arrange
            mockRepository
                .Setup(x => x.GetById(It.IsAny<int>()))
                .ReturnsAsync(new RepairOrder
                {
                    Id = 1,
                    Customer = new User(),
                    RegistrationDate = DateTime.Now
                });

            // Act
            var order = await service.GetById(1);

            // Assert
            order.Id.Should().Be(1);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-10)]
        public async Task Should_throwArgumentOutOfRangeException_When_IdIsZeroOrNegative(int id)
        {
            // Act
            Func<Task> action = async () => await service.GetById(id);

            // Assert
            await action.Should().ThrowAsync<ArgumentOutOfRangeException>();
        }
    }
}
