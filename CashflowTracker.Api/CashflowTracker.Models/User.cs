using System;
using System.Collections.Generic;
using System.Text;

namespace CashflowTracker.Models
{
    public class User : Entity
    {
        public override long Id { get; set; }
        public string Login { get; set; }
        public string UniqueIdentifier { get; set; }
        public ICollection<EventUser> EventUsers { get; set; }
        public ICollection<Role> Roles { get; set; }
        public ICollection<Debt> Debts { get; set; }
    }
}
