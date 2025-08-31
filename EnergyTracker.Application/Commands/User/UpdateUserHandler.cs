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
    public class UpdateUserHandler : IRequestHandler<UpdateUser , Unit>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(UpdateUser request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.UserId);

            if (user == null)
                throw new NotFoundException(nameof(user), request.UserId);

            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Email = request.Email;

            await _userRepository.UpdateAsync(user);

            return Unit.Value;
        }
    }
}
