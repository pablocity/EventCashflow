using System;
using System.Collections.Generic;
using System.Text;

namespace CashflowTracker.Contracts.Commands
{
    public class EventCreateCommand
    {
        public string EventName { get; set; }
        public string Description { get; set; }
        public DateTime? EventDate { get; set; }
    }
}
