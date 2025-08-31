using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyTracker.Domain.Entities
{
    public class Subscription
    {
        public Guid SubscriptionId { get; set; }  

        public Guid UserId { get; set; }         

        public string PlanName { get; set; }      

        public DateTime StartDate { get; set; }  

        public DateTime? EndDate { get; set; }   
        public User User { get; set; }
      
    }
}
