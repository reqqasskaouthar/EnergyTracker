using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyTracker.Domain.Events
{
    public class UserCreatedEvent : IDomainEvent, INotification
    {
        public Guid UserId { get; }
        public string Email { get; }

        public UserCreatedEvent(Guid userId, string email)
        {
            UserId = userId;
            Email = email;
        }
    }
}
