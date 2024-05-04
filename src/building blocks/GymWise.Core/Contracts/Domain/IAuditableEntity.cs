namespace GymWise.Core.Contracts.Domain
{
    public interface IAuditableEntity
    {
        public DateTime CreatedOnUtc { get; }
        public DateTime? UpdatedOnUtc { get; }
    }
}
