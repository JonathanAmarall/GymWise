using GymWise.Core.Contracts.Authentication;
using GymWise.Core.Models.PagedList;
using GymWise.Workout.Domain.Entities;
using GymWise.Workout.Infra.Persistence;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymWise.Api.Controllers
{
    [Route("api/v1/exercises")]
    [ApiController]
    [Authorize]
    public class ExercisesController : MainController
    {
        private readonly IUserContext _userContext;
        private readonly WorkoutDbContext _context;
        public ExercisesController(IMediator mediator, WorkoutDbContext context, IUserContext userContext) : base(mediator)
        {
            _context = context;
            _userContext = userContext;
        }

        [HttpGet]
        public async Task<IActionResult> Search(int pageNumber = 1, int pageSize = 10)
        {
            var user = _userContext.UserId;

            return Ok(await _context.Set<Exercise>().AsNoTracking().ToPagedListAsync(pageNumber, pageSize));
        }
    }
}
