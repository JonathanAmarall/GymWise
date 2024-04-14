using GymWise.Core.Models.PagedList;
using GymWise.Workout.Domain.Entities;
using GymWise.Workout.Infra.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymWise.Api.Controllers
{
    [Route("api/v1/exercises")]
    [ApiController]
    public class ExercisesController : MainController
    {
        private readonly WorkoutDbContext _context;
        public ExercisesController(IMediator mediator, WorkoutDbContext context) : base(mediator)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Search(int pageNumber = 1, int pageSize = 10)
            => Ok(await _context.Set<Exercise>().AsNoTracking().ToPagedListAsync(pageNumber, pageSize));
    }
}
