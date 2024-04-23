using GymWise.Core.Contracts;
using GymWise.Core.Models.Maybe;
using GymWise.Student.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GymWise.Student.Infra.Persistence.Repositories
{
    internal class StudentRepository : IStudentRepository
    {
        private readonly StudentDbContext _context;

        public StudentRepository(StudentDbContext context)
        {
            ArgumentException.ThrowIfNullOrEmpty(nameof(context));
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<Maybe<Domain.Entities.Student?>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
            => await _context.Set<Domain.Entities.Student>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        public async Task InsertAsync(Domain.Entities.Student student, CancellationToken cancellationToken = default)
            => await _context.Set<Domain.Entities.Student>().AddAsync(student, cancellationToken);

        public void Remove(Guid id, CancellationToken cancellationToken = default)
        {
            var student = _context.Set<Domain.Entities.Student>().FirstOrDefault(x => x.Id == id);
            if (student is null) { return; }
            _context.Set<Domain.Entities.Student>().Remove(student);
        }

        public async Task<bool> CheckExistsAsync(Guid id, CancellationToken cancellationToken = default)
            => await _context.Set<Domain.Entities.Student>().AnyAsync(x => x.Id == id, cancellationToken);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context?.Dispose();
            }
        }
    }
}
