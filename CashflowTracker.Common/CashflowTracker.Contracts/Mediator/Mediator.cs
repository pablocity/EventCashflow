using CashflowTracker.Contracts.Mediator.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Linq;
using CashflowTracker.Contracts.Configurations;

namespace CashflowTracker.Contracts.Mediator
{
    public class Mediator : IMediator
    {
        public Assembly HandlersAssembly { get; set; }

        private readonly HandlersFactory factory;
        private readonly IMediatorConfiguration options;

        public Mediator(HandlersFactory factory, IMediatorConfiguration options)
        {
            this.options = options;
            this.factory = factory;

            HandlersAssembly = options.HandlersAssembly;
        }

        public async Task<TResponse> Get<TResponse>(IRequest<TResponse> request)
        {
            var handler = options.UseAutofac ? ResolveHandler(request) : FindHandler(request);

            Type handlerType = handler.GetType();

            if (handler == null)
                throw new Exception("Handler with specified IRequest and TResponse wasn't found!");

            MethodInfo handleMethod = handlerType
                .GetTypeInfo()
                .GetMethod("Handle");

            var handleResult = handleMethod.Invoke(handler, new object[] { request });

            return await (Task<TResponse>)handleResult;
        }

        private object ResolveHandler<TResponse>(IRequest<TResponse> request)
        {
            Type requestHandlerType = typeof(IRequestHandler<,>);
            Type requestType = request.GetType();
            Type resultType = requestHandlerType.MakeGenericType(requestType, typeof(TResponse));

            var handler = factory(resultType);

            return handler;
        }

        private object FindHandler<TResponse>(IRequest<TResponse> request)
        {
            Type requestHandlerType = typeof(IRequestHandler<,>);
            Type requestType = request.GetType();
            Type resultType = requestHandlerType.MakeGenericType(requestType, typeof(TResponse));

            var handlerArguments = resultType.GetGenericArguments();
            var handlerRequest = handlerArguments
                .Single(x => x.GetInterfaces()
                        .FirstOrDefault(y => y.IsGenericType
                                && y.GetGenericTypeDefinition() == typeof(IRequest<>)) != null);

            var handlerResponse = handlerArguments.Single(x => x == typeof(TResponse));

            var handler = HandlersAssembly
                .GetTypes()
                .FirstOrDefault(type => IsHandler(handlerRequest, handlerResponse, type));

            return Activator.CreateInstance(handler);
        }

        private bool IsHandler(Type request, Type response, Type typeToCheck)
        {
            foreach (var i in typeToCheck.GetInterfaces())
            {
                if (!i.IsGenericType || i.GetGenericTypeDefinition() != typeof(IRequestHandler<,>))
                    continue;

                var arguments = i.GetGenericArguments();

                var requestArg = arguments
                                .FirstOrDefault(x => x == request);

                var responseArg = arguments.FirstOrDefault(x => x == response);

                if (response == responseArg && requestArg != null)
                    return true;
            }

            return false;
        }
    }
}
