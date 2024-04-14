using GymWise.Core.Errors;
using GymWise.Core.Models.Result;

namespace GymWise.Workout.Domain.ValueObjetcts
{
    public record Title(string Value)
    {
        public const short MaxLength = 100;
        public const short MinLength = 3;

        public static Result<Title> Create(string title)
            => Result.Create(title, DomainErrors.Title.NullOrEmpty)
                .Ensure(t => t.Length <= MaxLength, DomainErrors.Title.LongerThanAllowed)
                .Ensure(t => t.Length >= MinLength, DomainErrors.Title.LessThanAllowed)
                .Map(t => new Title(t));
    }
}
