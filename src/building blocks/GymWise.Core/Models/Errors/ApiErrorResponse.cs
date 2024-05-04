using GymWise.Core.Models.Primitives;

namespace GymWise.Core.Models.Errors
{
    public record ApiErrorResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiErrorResponse"/> class.
        /// </summary>
        /// <param name="errors">The enumerable collection of errors.</param>
        public ApiErrorResponse(ICollection<Error> errors) => Errors = errors;
        public ApiErrorResponse() { }

        /// <summary>
        /// Gets the errors.
        /// </summary>
        public ICollection<Error> Errors { get; } = Enumerable.Empty<Error>().ToList();

        public void AddError(Error error) => Errors.Add(error);

        public void ClearErrors() => Errors.Clear();

        public void AddErrors(ICollection<Error> errors)
        {
            foreach (var error in errors)
            {
                Errors.Add(error);
            }
        }

        public bool HasErrors() => Errors.Count > 0;
    }
}
