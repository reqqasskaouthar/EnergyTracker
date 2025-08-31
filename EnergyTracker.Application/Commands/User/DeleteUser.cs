using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyTracker.Application.Commands.User
{
    public class DeleteUser : IRequest<Unit>
    {
        public Guid UserId { get; }

        public DeleteUser(Guid userId)
        {
            UserId = userId;
        }
    }
}
