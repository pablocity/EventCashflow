using System;
using System.Collections.Generic;
using System.Text;

namespace CashflowTracker.Contracts.Dtos
{
    public class EventDto
    {
        public long Id { get; set; }
        public string EventName { get; set; }
        public string Description { get; set; }
        public DateTime? EventDate { get; set; }
    }
}
