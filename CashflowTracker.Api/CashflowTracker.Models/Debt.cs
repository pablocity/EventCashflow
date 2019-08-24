using System;
using System.Collections.Generic;
using System.Text;

namespace CashflowTracker.Models
{
    public class Debt : Entity
    {
        public override long Id { get; set; }
        public long UserId { get; set; }
        public long CostItemId { get; set; }
        public CostItem CostItem { get; set; }
        public decimal DebtAmount { get; set; }
        public long DebtHolderId { get; set; }
    }
}
