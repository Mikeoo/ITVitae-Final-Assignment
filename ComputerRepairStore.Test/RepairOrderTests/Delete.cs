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
    public class Delete
    {
        readonly RepairOrderService service;
        readonly Mock<IRepository<RepairOrder>> mockRepository;

        public Delete()
        {
            mockRepository = new();
            service = new(mockRepository.Object);
        }

        [Fact]
        public async Task Should_ExecuteDeleteOnce()
        {
            // Arrange
            mockRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(Task.FromResult(new RepairOrder()));

            // Act
            await service.Delete(1);

            // Assert
            mockRepository.Verify(x => x.Delete(It.IsAny<int>()), Times.Once);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-10)]
        public async Task Should_ThrowArgumentOutOfRangeException_When_IdIsZeroOrNegative(int id)
        {
            // Act
            Func<Task> action = async () => await service.Delete(id);

            // Assert
            await action.Should().ThrowAsync<ArgumentOutOfRangeException>();
        }
    }
}
