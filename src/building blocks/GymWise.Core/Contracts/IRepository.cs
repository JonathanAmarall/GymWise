using GymWise.Core.Primitives;

namespace GymWise.Core.Contracts
{
    public interface IRepository<T> : IDisposable where T : AggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
