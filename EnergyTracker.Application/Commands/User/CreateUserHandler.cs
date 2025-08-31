using EnergyTracker.Domain.Entities;
using EnergyTracker.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyTracker.Application.Commands.User
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IUserRepository _userRepository;
        public CreateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new EnergyTracker.Domain.Entities.User(request.FirstName, request.LastName, request.Email);
            await _userRepository.AddAsync(user);
            return user.UserId;
        }
    }
}
