using Autofac;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashflowTracker.Handlers
{
    public class HandlerModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(type => type.Name.EndsWith("Handler", System.StringComparison.InvariantCulture))
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(t => t.Name.EndsWith("Profile", StringComparison.InvariantCulture))
                .As<Profile>();

            base.Load(builder);
        }
    }
}
