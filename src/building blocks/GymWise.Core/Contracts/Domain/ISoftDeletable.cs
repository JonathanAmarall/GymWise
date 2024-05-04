namespace GymWise.Core.Contracts.Domain
{
    public interface ISoftDeletable
    {
        bool IsDeleted { get; }

        DateTime? DeletedOnUtc { get; }
    }
}
