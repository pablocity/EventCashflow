using System;
using System.Collections.Generic;
using System.Text;

namespace CashflowTracker.Models
{
    public abstract class Entity
    {
        public abstract long Id { get; set; }
    }
}
