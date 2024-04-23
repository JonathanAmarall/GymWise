using GymWise.Core.Contracts;
using GymWise.Core.Models.Maybe;

namespace GymWise.Student.Domain.Repositories
{
    public interface IStudentRepository : IRepository<Entities.Student>
    {
        Task<bool> CheckExistsAsync(Guid id, CancellationToken cancellationToken = default);

        Task<Maybe<Entities.Student?>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task InsertAsync(Entities.Student student, CancellationToken cancellationToken = default);

        void Remove(Guid id, CancellationToken cancellationToken = default);
    }
}
