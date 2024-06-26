﻿using GymWise.Api.Models;
using GymWise.Api.Models.Requests.Students;
using GymWise.Core.Models.Auth;
using GymWise.Core.Models.Errors;
using GymWise.Core.Models.Events.IntegrationEvents;
using GymWise.Core.Models.PagedList;
using GymWise.Core.Models.Result;
using GymWise.Core.Models.ValueObjects;
using GymWise.Student.Infra.Persistence;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymWise.Api.Controllers
{
    [Route("api/v1/students")]
    public class StudentsController : MainController
    {
        private readonly UserManager<User> _userManager;
        private readonly StudentDbContext _context;
        public StudentsController(
            IMediator mediator,
            UserManager<User> userManager,
            StudentDbContext context) : base(mediator)
        {
            _userManager = userManager;
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(typeof(Student.Domain.Entities.Student), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(int pageNumber = 1, int pageSize = 10)
             => Ok(await _context.Set<Student.Domain.Entities.Student>().AsNoTracking().ToPagedListAsync(pageNumber, pageSize));

        [HttpPost("register")]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> CreateStudent(CreateStudentRequest request)
        {
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

            await PublishNewStudentUserCreatedIntegrationEvent(request, document, newStudentUser, studentAleatoryPassword);

            return NoContent();
        }

        private async Task PublishNewStudentUserCreatedIntegrationEvent(CreateStudentRequest request, Result<Document> document, User newStudentUser, string studentAleatoryPassword)
            => await Mediator.Publish(new NewStudentUserCreatedIntegrationEvent(
                    newStudentUser.Id,
                    request.FirstName,
                    request.LastName,
                    request.PhoneNumber,
                    request.DateOfBirth,
                    document.Value,
                    studentAleatoryPassword,
                    newStudentUser.Email!));

        private static string GenerateAleatoryPasswordFromUser(User newStudentUser, Document document)
            => $"{document.Value.Substring(0, 3)}{newStudentUser.UserName!.Substring(0, 3)}";
    }
}
