using EnergyTracker.Application.Commands.User;
using EnergyTracker.Application.Common.Exceptions;
using EnergyTracker.Domain.Entities;
using EnergyTracker.Domain.Interfaces;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyTracker.Tests
{
    public class UpdateUserHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldUpdateUser_WhenUserExists()
        {
            var userId = Guid.NewGuid();
            var user = new User("kaouthar", "Reqqass", "re.kaouthar@gmail.com") { UserId = userId };

            var mockRepo = new Mock<IUserRepository>();
            mockRepo.Setup(r => r.GetByIdAsync(userId)).ReturnsAsync(user);
            mockRepo.Setup(r => r.UpdateAsync(It.IsAny<User>())).Returns(Task.CompletedTask);

            var handler = new UpdateUserHandler(mockRepo.Object);
            var command  = new UpdateUser(userId, "kaouthar", "Zaid", "Kaouthar.zaid@gmail.com");
            var result = await handler.Handle(command, CancellationToken.None);
            Assert.Equal("kaouthar", user.FirstName);
            Assert.Equal("Zaid", user.LastName);
            Assert.Equal("Kaouthar.zaid@gmail.com", user.Email);

            mockRepo.Verify(r => r.UpdateAsync(It.Is<User>(u =>
                u.UserId == userId &&
                u.FirstName == "kaouthar" &&
                u.LastName == "Zaid" &&
                u.Email == "Kaouthar.zaid@gmail.com"
            )), Times.Once);

            Assert.Equal(Unit.Value, result);
        }
        [Fact]
        public async Task Handle_ShouldThrowNotFoundException_WhenUserDoesNotExist()
        {
            var userId = Guid.NewGuid();

            var mockRepo = new Mock<IUserRepository>();
            mockRepo.Setup(r => r.GetByIdAsync(userId)).ReturnsAsync((User)null);

            var handler = new UpdateUserHandler(mockRepo.Object);
            var command = new UpdateUser(userId, "Test", "User", "test@example.com");

            await Assert.ThrowsAsync<NotFoundException>(() =>
                handler.Handle(command, CancellationToken.None)
            );
        }
    }
}



