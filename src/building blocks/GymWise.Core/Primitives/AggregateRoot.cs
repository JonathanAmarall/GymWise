using GymWise.Core.Contracts;
using System.Text.Json.Serialization;

namespace GymWise.Core.Primitives
{
    public abstract class AggregateRoot : EntityBase
    {
        protected AggregateRoot() { }

        protected AggregateRoot(Guid id) : base(id) { }

        private readonly List<IDomainEvent> _domainEvents = new();
        [JsonIgnore]
        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        public void ClearDomainEvents() => _domainEvents.Clear();

        protected void AddDomainEvent(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);
    }
}
