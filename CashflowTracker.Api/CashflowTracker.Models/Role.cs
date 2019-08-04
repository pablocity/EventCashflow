using System;
using System.Collections.Generic;
using System.Text;

namespace CashflowTracker.Models
{
    public class Role : Entity
    {
        public override long Id { get; set; }
        public long RoleTypeId { get; set; }
        public RoleType RoleType { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
    }
}
