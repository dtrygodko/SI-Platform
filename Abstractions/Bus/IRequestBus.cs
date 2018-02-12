using System.Threading.Tasks;
using Abstractions.CQRS;

namespace Abstractions.Bus
{
    public interface IRequestBus
    {
        Task<TResponse> RequestAsync<TRequest, TResponse>(TRequest request)
            where TRequest : IRequest<TResponse>
            where TResponse : IResponse;
    }
}