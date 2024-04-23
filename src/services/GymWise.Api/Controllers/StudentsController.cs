using GymWise.Api.Models;
using GymWise.Api.Models.Requests.Students;
using GymWise.Core.Auth;
using GymWise.Core.Events.IntegrationEvents;
using GymWise.Core.Models.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GymWise.Api.Controllers
{
    [Route("api/v1/students")]
    public class StudentsController : MainController
    {
        private readonly UserManager<User> _userManager;
        public StudentsController(
            IMediator mediator,
            UserManager<User> userManager) : base(mediator)
        {
            _userManager = userManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> CreateStudent(CreateStudentRequest request)
        {
            // validar request
            var document = Document.Create(request.Document);

            if (document.IsFailure)
            {
                return ErrorResponse(document.Error);
            }

            var newStudentUser = new User(request.UserName, request.Email, request.PhoneNumber);

            string studentAleatoryPassword = GenerateAleatoryPasswordFromUser(newStudentUser, document.Value);

            var result = await _userManager.CreateAsync(newStudentUser, studentAleatoryPassword);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    AddProcessingError(error.Code, error.Description);
                }

                return CustomReponse();
            }

            var addRoleResult = await _userManager.AddToRoleAsync(newStudentUser, Roles.Student);
            if (!addRoleResult.Succeeded)
            {
                await _userManager.DeleteAsync(newStudentUser);
                // TODO: add logger
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            await Mediator.Publish(new NewStudentUserCreatedIntegrationEvent(
                newStudentUser.Id,
                request.FirstName,
                request.LastName,
                request.PhoneNumber,
                request.DateOfBirth,
                document.Value,
                studentAleatoryPassword));

            return CustomReponse();
        }

        private static string GenerateAleatoryPasswordFromUser(User newStudentUser, Document document)
            => $"{document.Value.Substring(0, 3)}{newStudentUser.UserName!.Substring(0, 3)}";
    }
}
