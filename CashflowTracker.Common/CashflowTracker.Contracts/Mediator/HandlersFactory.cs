using System;
using System.Collections.Generic;
using System.Text;

namespace CashflowTracker.Contracts.Mediator
{
    public delegate object HandlersFactory(Type typeToResolve);
}
