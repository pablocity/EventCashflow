using System;
using System.Collections.Generic;
using System.Text;

namespace CashflowTracker.Models
{
    public class RoleType : Entity
    {
        public override long Id { get; set; }
        public string Name { get; set; }
    }
}
