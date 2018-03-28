using System.Threading.Tasks;

namespace Abstractions.CQRS
{
    public interface IRequestHandler<in TRequest, TResponse>
        where TRequest : IRequest<TResponse> where TResponse : IResponse
    {
        Task<TResponse> ExecuteAsync(TRequest request);
    }
}