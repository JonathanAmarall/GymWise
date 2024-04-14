using GymWise.Api.Models.Requests.WorkoutRotine;
using GymWise.Api.Models.Requests.Workouts;
using GymWise.Core.Models.PagedList;
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
        public WorkoutsController(IMediator mediator, WorkoutDbContext context) : base(mediator)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Search(int pageNumber = 1, int pageSize = 10)
            => Ok(await _context.Set<Workout.Domain.Entities.Workout>()
                .AsNoTracking()
                .Include(x => x.Sets)
                .ThenInclude(x => x.Exercise).AsNoTracking()
                .Include(x => x.TrainingRoutine).AsNoTracking()
                .ToPagedListAsync(pageNumber, pageSize));

        [HttpPost]
        public async Task<IActionResult> CreateWorkout([FromBody] CreateWorkoutRequest request, CancellationToken cancellationToken)
        {
            var command = request.CreateCommand();
            var result = await Mediator.Send(command, cancellationToken);
            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return Ok(result.Value);
        }

        [HttpPost("rotines")]
        public async Task<IActionResult> CreateWorkoutRotine([FromBody] CreateWorkoutRotineRequest request, CancellationToken cancellationToken = default)
        {
            var command = request.CreateCommand();
            var result = await Mediator.Send(command, cancellationToken);
            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return Ok(result.Value);
        }
    }
}
