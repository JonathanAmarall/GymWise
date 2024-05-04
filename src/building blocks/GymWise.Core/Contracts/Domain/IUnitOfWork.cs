namespace GymWise.Core.Contracts.Domain
{
    public interface IUnitOfWork
    {
        Task<bool> Commit(CancellationToken cancellationToken = default);
    }
}
