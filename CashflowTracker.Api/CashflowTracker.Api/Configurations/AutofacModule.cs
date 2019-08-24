using Autofac;
using AutoMapper;
using CashflowTracker.Contracts.Configurations;
using CashflowTracker.Contracts.Mediator;
using CashflowTracker.Contracts.Mediator.Interfaces;
using CashflowTracker.Handlers;
using CashflowTracker.Handlers.Events.Queries;
using CashflowTracker.Repositories.Implementations;
using CashflowTracker.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CashflowTracker.Api.Configurations
{
    public class AutofacModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(type => type.Name.EndsWith("Handler", System.StringComparison.InvariantCulture))
                .AsImplementedInterfaces();

            builder.Register<HandlersFactory>(context =>
            {
                var ctx = context.Resolve<IComponentContext>();

                return type => ctx.Resolve(type);
            });

            builder.RegisterType<MediatorConfiguration>().As<IMediatorConfiguration>();
            builder.RegisterType<Mapper>().As<IMapper>();
            builder.RegisterType<Mediator>().As<IMediator>().SingleInstance();

            base.Load(builder);
        }
    }
}
