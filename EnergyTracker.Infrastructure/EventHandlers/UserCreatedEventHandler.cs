using EnergyTracker.Domain.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyTracker.Infrastructure.EventHandlers
{
    public class UserCreatedEventHandler : INotificationHandler<UserCreatedEvent>
    {
        public Task Handle(UserCreatedEvent notification, CancellationToken cancellationToken)
        {
            // Par exemple : log, envoyer un email, ou autre action
            Console.WriteLine($"Nouvel utilisateur créé avec Email = {notification.Email}");

            return Task.CompletedTask;
        }
    }
}


