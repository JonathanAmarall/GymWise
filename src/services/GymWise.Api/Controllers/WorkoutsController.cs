using GymWise.Api.Models.Requests.WorkoutRotine;
using GymWise.Api.Models.Requests.Workouts;
using GymWise.Core.Errors;
using GymWise.Core.Models.PagedList;
using GymWise.Student.Domain.Repositories;
using GymWise.Workout.Application.Workouts.Queries.GetWorkoutByStudentId;
using GymWise.Workout.Infra.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymWise.Api.Controllers
{
    [Route("api/v1/workouts")]
    [ApiController]
    public class WorkoutsController : MainController
    {
        private readonly WorkoutDbContext _context;
        private readonly IStudentRepository _studentRepository;
        public WorkoutsController(
            IMediator mediator,
            WorkoutDbContext context,
            IStudentRepository studentRepository) : base(mediator)
        {
            _context = context;
            _studentRepository = studentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Search(int pageNumber = 1, int pageSize = 10)
            => Ok(await _context.Set<Workout.Domain.Entities.Workout>()
                .AsNoTracking()
                .Include(x => x.Sets)
                .ThenInclude(x => x.Exercise).AsNoTracking()
                .Include(x => x.WorkoutRoutine).AsNoTracking()
                .ToPagedListAsync(pageNumber, pageSize));

        [HttpGet("student/{studentId}")]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(Workout.Domain.Entities.Workout), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByStudentId(Guid studentId, CancellationToken cancellationToken)
        {
            var query = new GetWorkoutByStudentIdQuery(studentId);
            var result = await Mediator.Send(query, cancellationToken);

            if (result.HasNoValue)
            {
                return NoContent();
            }

            return Ok(result.Value);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateWorkout([FromBody] CreateWorkoutRequest request, CancellationToken cancellationToken)
        {
            var command = request.CreateCommand();
            var result = await Mediator.Send(command, cancellationToken);
            if (result.IsFailure)
            {
                return ErrorResponse(result.Error);
            }

            return Ok(result.Value);
        }

        [HttpPost("rotines")]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateWorkoutRotine([FromBody] CreateWorkoutRotineRequest request, CancellationToken cancellationToken = default)
        {
            if (!IsValidAndNotNullStudentId(request) && !await _studentRepository.CheckExistsAsync(request.StudentId!.Value, cancellationToken))
            {
                return NotFound();
            }

            var result = await Mediator.Send(request.CreateCommand(), cancellationToken);
            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return NoContent();
        }

        private static bool IsValidAndNotNullStudentId(CreateWorkoutRotineRequest request)
            => request.StudentId != null && request.StudentId != Guid.Empty;
    }
}
