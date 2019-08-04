using System;
using System.Collections.Generic;
using System.Text;

namespace CashflowTracker.Models
{
    public class Payment : Entity
    {
        public override long Id { get; set; }
        public long UserId { get; set; }
        public long CostItemId { get; set; }
        public CostItem CostItem { get; set; }
        public decimal Amount { get; set; }
        public bool IsApproved { get; set; }
    }
}
