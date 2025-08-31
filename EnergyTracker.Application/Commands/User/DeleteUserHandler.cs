using EnergyTracker.Application.Common.Exceptions;
using EnergyTracker.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyTracker.Application.Commands.User
{
    public class DeleteUserHandler : IRequestHandler<DeleteUser , Unit>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(DeleteUser request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.UserId);
            if (user == null)
            {
                throw new NotFoundException("User not found");
            }

            await _userRepository.DeleteAsync(request.UserId);
            return Unit.Value;
        }
    }
}
