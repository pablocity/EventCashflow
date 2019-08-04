using System;
using System.Collections.Generic;
using System.Text;

namespace CashflowTracker.Models
{
    public class Event : Entity
    {
        public override long Id { get; set; }
        public string EventName { get; set; }
        public string Description { get; set; }
        public DateTime? EventDate { get; set; }
        public ICollection<EventUser> EventUsers { get; set; }
        public ICollection<CostItem> CostItems { get; set; }
    }
}
