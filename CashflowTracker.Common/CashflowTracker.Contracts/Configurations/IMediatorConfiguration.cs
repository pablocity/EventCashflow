using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CashflowTracker.Contracts.Configurations
{
    public interface IMediatorConfiguration
    {
        bool UseAutofac { get; }
        Assembly HandlersAssembly { get; }
    }
}
