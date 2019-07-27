using System;
using System.Collections.Generic;
using System.Text;

namespace CashflowTracker.Models
{
    public class EventUser
    {
        public long EventId { get; set; }
        public Event Event { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
    }
}
