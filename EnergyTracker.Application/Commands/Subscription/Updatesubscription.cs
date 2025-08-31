﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyTracker.Application.Commands.Subscription
{
    public class Updatesubscription: IRequest<Unit>
    {
        public Guid SubscriptionId { get; set; }    
        public Guid UserId { get; set; }           
        public string PlanName { get; set; }        
        public DateTime StartDate { get; set; }     
        public DateTime? EndDate { get; set; }      
    }
}

