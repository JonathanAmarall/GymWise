using GymWise.Core.Primitives;

namespace GymWise.Core.Errors
{
    public static class DomainErrors
    {
        public static class Title
        {
            public static Error NullOrEmpty = new Error("Title.NullOrEmpty", "Title is required.");
            public static Error LongerThanAllowed => new Error("Title.LongerThanAllowed", "The Title is longer than allowed.");
            public static Error LessThanAllowed => new Error("Title.LessThanAllowed", "The Title is less than allowed.");
        }

        public static class Sets
        {

            public static Error RepsMaximumValueExceeded = new Error("Sets.RepsMaximumValueExceeded", "The maximum number of repetitions has been reached");
            public static Error RepsMinimumValueExceeded = new Error("Sets.RepsMinimumValueExceeded", "The Minimum number of repetitions has been reached");
        }

        public static class General
        {
            public static Error FailedToInstantiate = new Error("General.FailedToInstantiate", "Failed to instantiate the entity");

            public static Error UnProcessableRequest => new Error(
                "General.UnProcessableRequest",
                "The server could not process the request.");

            public static Error ServerError => new Error("General.ServerError", "The server encountered an unrecoverable error.");

        }
    }
}
