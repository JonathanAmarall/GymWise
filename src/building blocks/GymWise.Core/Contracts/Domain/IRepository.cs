using GymWise.Core.Models.Primitives;

namespace GymWise.Core.Contracts.Domain
{
    public interface IRepository<T> : IDisposable where T : AggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
