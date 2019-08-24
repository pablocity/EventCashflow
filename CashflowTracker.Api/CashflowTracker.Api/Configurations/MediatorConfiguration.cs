using CashflowTracker.Contracts.Configurations;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CashflowTracker.Api.Configurations
{
    public class MediatorConfiguration : IMediatorConfiguration
    {
        private readonly IOptions<MediatorOptions> mediatorOptions;

        public MediatorConfiguration(IOptions<MediatorOptions> mediatorOptions)
        {
            this.mediatorOptions = mediatorOptions;
        }

        public bool UseAutofac => mediatorOptions.Value.UseAutofac;
        public Assembly HandlersAssembly => mediatorOptions.Value.HandlersAssembly;
    }
}
