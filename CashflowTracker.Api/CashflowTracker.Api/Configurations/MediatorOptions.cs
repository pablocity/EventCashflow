using CashflowTracker.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CashflowTracker.Api.Configurations
{
    public class MediatorOptions
    {
        public bool UseAutofac { get; set; }
        public Assembly HandlersAssembly { get; set; } = typeof(HandlersAssemblyAnchor).Assembly;
    }
}
