using System;
using System.Threading.Tasks;
using Abstractions.Bus;
using Abstractions.CQRS;
using Autofac;

namespace Infrastructure.Bus
{
    public class RequestBus : IRequestBus
    {
        private readonly ILifetimeScope _container;

        public RequestBus(ILifetimeScope container)
        {
            _container = container;
        }

        public async Task<TResponse> RequestAsync<TRequest, TResponse>(TRequest request) where TRequest : IRequest<TResponse> where TResponse : IResponse
        {
            var handler = _container.ResolveOptional<IRequestHandler<TRequest, TResponse>>();

            if (handler == null)
            {
                throw new Exception("Unknown request");
            }

            return await handler.ExecuteAsync(request);
        }
    }
}