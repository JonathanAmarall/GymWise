namespace GymWise.Core.Contracts
{
    public interface ISoftDeletable
    {
        bool IsDeleted { get; }

        DateTime? DeletedOnUtc { get; }
    }
}
