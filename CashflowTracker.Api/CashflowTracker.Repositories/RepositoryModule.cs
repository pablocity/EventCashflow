using System;
using System.Collections.Generic;
using System.Text;
using Autofac;

namespace CashflowTracker.Repositories
{
    public class RepositoryModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(type => type.Name.EndsWith("Repository", System.StringComparison.InvariantCulture))
                .AsImplementedInterfaces();

            base.Load(builder);
        }
    }
}
