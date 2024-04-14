using GymWise.Core.Contracts;

namespace GymWise.Core.Primitives
{
    public abstract class AggregateRoot : EntityBase
    {
        protected AggregateRoot() { }

        protected AggregateRoot(Guid id) : base(id) { }

        private readonly List<IDomainEvent> _domainEvents = new();

        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        public void ClearDomainEvents() => _domainEvents.Clear();

        protected void AddDomainEvent(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);
    }
}
