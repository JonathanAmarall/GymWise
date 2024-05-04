using MediatR;

namespace GymWise.Core.Contracts.Messaging
{
    public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
       where TCommand : ICommand<TResponse>
    {
    }
}
