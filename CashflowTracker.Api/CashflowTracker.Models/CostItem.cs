using System;
using System.Collections.Generic;
using System.Text;

namespace CashflowTracker.Models
{
    public class CostItem : Entity
    {
        public override long Id { get; set; }
        public long EventId { get; set; }
        public Event Event { get; set; }
        public decimal Price { get; set; }
        public bool IsPaid { get; set; }
        public ICollection<Payment> Payments { get; set; }
    }
}
