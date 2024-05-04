using MediatR;

namespace GymWise.Core.Contracts.Messaging
{
    public interface IIntegrationEventHandler<in TIntegrationEvent> : INotificationHandler<TIntegrationEvent>
       where TIntegrationEvent : IIntegrationEvent
    { }
}
