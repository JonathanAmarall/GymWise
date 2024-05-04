using GymWise.Core.Errors;
using GymWise.Core.Models.Primitives;
using Microsoft.AspNetCore.Mvc;

public static class InvalidModelStatelApiBehaviorConfiguration
{
    public static IMvcBuilder ConfigureInvalidStateApiBehavior(this IMvcBuilder builder)
    {
        builder.ConfigureApiBehaviorOptions(options =>
        {
            options.InvalidModelStateResponseFactory = (errorContext) =>
            {
                var errors = errorContext.ModelState.Values.SelectMany(e => e.Errors);
                var errorsResponse = new List<Error>();

                foreach (var error in errors)
                {
                    errorsResponse.Add(new Error("GymWise.Validation", error.ErrorMessage));
                }

                return new BadRequestObjectResult(new ApiErrorResponse(errorsResponse));
            };
        });

        return builder;
    }
}