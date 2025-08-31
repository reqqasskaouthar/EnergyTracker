using EnergyTracker.Application.DTOs;
using EnergyTracker.Domain.Interfaces;
using MediatR;
using MediatR.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyTracker.Application.Queries.User
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsers, IEnumerable<UserDto>>
    {
        private readonly IUserRepository _userRepository;

        public GetAllUsersHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<IEnumerable<UserDto>> Handle(GetAllUsers request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetUsersAsync();

            return users.Select(user => new UserDto
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                CreateAT = user.CreatedAT.ToString("yyyy-MM-dd HH:mm")
            });
        }
    }
}
