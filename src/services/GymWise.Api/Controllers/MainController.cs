using GymWise.Core.Errors;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace GymWise.Api.Controllers
{
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        protected IMediator Mediator { get; }
        protected MainController(IMediator mediator) => Mediator = mediator;

        protected ApiErrorResponse ApiErrorResponse { get; private set; }

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

        }

        protected void AddProcessingErrors(List<string> errors)
        {

        }

        protected void AddProcessingErrors(ValidationResult validationResult)
        {

        }

        protected void ClearProcessingErrors()
        {

        }

        protected bool OperationValid()
        {
            return true;
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
