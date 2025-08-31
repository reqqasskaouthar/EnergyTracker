using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyTracker.Application.Commands.User
{
    public class UpdateUser : IRequest <Unit>
    {
        public Guid UserId { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }

        public UpdateUser(Guid userId, string firstName, string lastName, string email)
        {
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
    }
}
