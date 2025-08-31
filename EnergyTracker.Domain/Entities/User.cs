using EnergyTracker.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyTracker.Domain.Entities
{
    public class User
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        private readonly List<IDomainEvent> _domaineEvents = new();
        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domaineEvents.AsReadOnly();

        public DateTime CreatedAT { get; private set; }
        
        public User (string firstName, string lastName, string email)
        {
            this.UserId = Guid.NewGuid();
            this.CreatedAT = DateTime.UtcNow;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;

            var userCreatedEvent = new UserCreatedEvent(UserId, Email);
            _domaineEvents.Add(userCreatedEvent);
        }
        public void ClearDomainEvents()
        {
            _domaineEvents.Clear();
        }

    }
}
