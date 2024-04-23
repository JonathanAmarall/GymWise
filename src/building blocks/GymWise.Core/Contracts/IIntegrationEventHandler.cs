using MediatR;

namespace GymWise.Core.Contracts
{
    public interface IIntegrationEventHandler<in TIntegrationEvent> : INotificationHandler<TIntegrationEvent>
       where TIntegrationEvent : IIntegrationEvent
    { }
}
