using CashflowTracker.Contracts.Mediator.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Linq;

namespace CashflowTracker.Contracts.Mediator
{
    public class Mediator : IMediator
    {
        public Assembly HandlersAssembly { get; set; }

        public async Task<TResponse> Get<TResponse>(IRequest<TResponse> request)
        {
            var handler = FindHandler<TResponse>(request) as Type;

            if (handler == null)
                throw new Exception("Handler with specified IRequest and TResponse wasn't found!");

            MethodInfo handleMethod = handler
                .GetTypeInfo()
                .GetMethod("Handle");

            var handleResult = handleMethod.Invoke(Activator.CreateInstance(handler), new object[] { request });

            return await (Task<TResponse>)handleResult;
        }

        private object FindHandler<TResponse>(IRequest<TResponse> request)
        {
            Type requestHandlerType = typeof(IRequestHandler<,>);
            Type requestType = typeof(IRequest<>);
            Type requestWithResponseType = requestType.MakeGenericType(typeof(TResponse));
            Type resultType = requestHandlerType.MakeGenericType(requestWithResponseType, typeof(TResponse));

            var handlerArguments = resultType.GetGenericArguments();
            var handlerRequest = handlerArguments.Single(x => x.GetGenericTypeDefinition() == typeof(IRequest<>));
            var handlerResponse = handlerArguments.Single(x => x == typeof(TResponse));

            var handler = HandlersAssembly
                .GetTypes()
                .FirstOrDefault(type => IsHandler(handlerRequest, handlerResponse, type));

            return handler;
        }

        private bool IsHandler(Type request, Type response, Type typeToCheck)
        {
            foreach (var i in typeToCheck.GetInterfaces())
            {
                if (!i.IsGenericType || i.GetGenericTypeDefinition() != typeof(IRequestHandler<,>))
                    continue;

                var arguments = i.GetGenericArguments();

                var requestArg = arguments
                                .FirstOrDefault(x => x.IsInterface && x.IsGenericType && x == request 
                                    || x.GetInterfaces()
                                        .FirstOrDefault(y => y == request) != null);

                var responseArg = arguments.FirstOrDefault(x => x == response);

                if (response == responseArg && requestArg != null)
                    return true;
            }

            return false;
        }
    }
}
