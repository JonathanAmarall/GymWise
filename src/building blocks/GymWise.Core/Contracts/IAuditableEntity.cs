namespace GymWise.Core.Contracts
{
    public interface IAuditableEntity
    {
        public DateTime CreatedOnUtc { get; }
        public DateTime? UpdatedOnUtc { get; }
    }
}
