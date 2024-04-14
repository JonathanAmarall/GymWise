using MediatR;

namespace GymWise.Core.Contracts
{
    public interface ICommand<out TResponse> : IRequest<TResponse>
    {
    }
}
