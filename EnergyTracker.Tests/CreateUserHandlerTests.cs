using EnergyTracker.Application.Commands.User;
using EnergyTracker.Domain.Entities;
using EnergyTracker.Domain.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyTracker.Tests
{
    public class CreateUserHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldCreateUserAndReturnUserId()
        {
            var mockRepo = new Mock<IUserRepository>();
            mockRepo.Setup(repo => repo.AddAsync(It.IsAny<User>()))
                    .Returns(Task.CompletedTask);

            var handler = new CreateUserHandler(mockRepo.Object);

            var command = new CreateUserCommand
            {
                FirstName = "kaouthar",
                LastName = "Reqqass",
                Email = "kaoutharreqqass@gmail.com"
            };
            var result = await handler.Handle(command, CancellationToken.None);

            mockRepo.Verify(repo => repo.AddAsync(It.Is<User>(u =>
                u.FirstName == command.FirstName &&
                u.LastName == command.LastName &&
                u.Email == command.Email
            )), Times.Once);

            Assert.NotEqual(Guid.Empty, result);
        }
    }
}
