using MediatR;

namespace GymWise.Core.Contracts.Messaging
{
    public interface ICommand<out TResponse> : IRequest<TResponse>
    {
    }
}
