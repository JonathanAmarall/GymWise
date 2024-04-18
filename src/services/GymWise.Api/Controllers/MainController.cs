using FluentValidation.Results;
using GymWise.Core.Errors;
using GymWise.Core.Primitives;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;

namespace GymWise.Api.Controllers
{
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        protected IMediator Mediator { get; }
        protected MainController(IMediator mediator) => Mediator = mediator;

        private ApiErrorResponse ApiErrorResponse { get; set; } = new();

        protected ActionResult CustomReponse(object result = null!)
        {
            if (OperationValid())
            {
                return Ok(result);
            }

            return BadRequest(ApiErrorResponse);
        }

        protected ActionResult CustomReponse(ModelStateDictionary modelState)
        {
            var errors = modelState.Values.SelectMany(e => e.Errors);

            foreach (var error in errors)
            {
                AddProcessingError(error.ErrorMessage);
            }

            return CustomReponse();
        }

        protected void AddProcessingError(string error)
        {
            ApiErrorResponse.AddError(new Error(DomainErrors.General.UnProcessableRequest, error));
        }

        protected void AddProcessingErrors(ICollection<string> errors)
        {
            ApiErrorResponse.AddErrors(errors.Select(error => new Error(DomainErrors.General.UnProcessableRequest, error)).ToArray());
        }

        protected void AddProcessingErrors(ValidationResult validationResult)
        {
            ApiErrorResponse.AddErrors(validationResult.Errors.Select(error => new Error(error.ErrorCode, error.ErrorMessage)).ToArray());
        }

        protected void ClearProcessingErrors()
        {
            ApiErrorResponse.ClearErrors();
        }

        protected bool OperationValid()
        {
            return !ApiErrorResponse.HasErrors();
        }

        protected Guid GetUserId()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrWhiteSpace(userId))
                AddProcessingError("User not found.");

            if (!Guid.TryParse(userId, out Guid result))
                AddProcessingError("User not found.");

            return result;
        }
    }
}
