namespace GymWise.Core.Primitives
{
    public abstract class EntityBase
    {
        protected EntityBase()
        {
            Id = Guid.NewGuid();
        }

        protected EntityBase(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("The identifier is required.", nameof(id));
            }

            Id = id;
        }

        public Guid Id { get; private set; }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (obj is not EntityBase compareTo) return false;
            if (ReferenceEquals(this, compareTo)) return true;

            return Id.Equals(compareTo.Id);
        }

        public override int GetHashCode()
        {
            return GetType().GetHashCode() * 907 + Id.GetHashCode();
        }

        public override string ToString()
        {
            return $"{GetType().Name} [Id={Id}]";
        }
    }
}
