using GymWise.Core.Models.Primitives;

namespace GymWise.Core.Errors
{
    public static class DomainErrors
    {
        public static class Workout
        {
            public static Error NotFound = new Error("Workout.Exercise.NotFound", "Exercise not found.");
        }

        public static class WorkoutRotine
        {
            public static Error NotFound = new Error("Workout.WorkoutRotine.NotFound", "WorkoutRotine not found.");
        }

        public static class Student
        {
            public static Error NotFound = new Error("Student.NotFound", "The Student was not found.");
        }

        public static class Document
        {
            public static Error InvalidDocument = new Error("Document.InvalidDocument", "The document is not valid.");
            public static Error InvalidDocumentLength = new Error("Document.InvalidDocumentLength", "The document length is not valid.");
        }

        public static class Address
        {
            public static Error NotFound = new Error("Address.NotFound", "The address with the specified identifier was not found.");
            public static Error ZipCodeIsNotValid;

            public static Error NumberLengthIsNotValid { get; set; }
            public static Error CityLengthIsNotValid { get; set; }
            public static Error StateLengthIsNotValid { get; set; }
            public static Error NeighborhoodLengthIsNotValid { get; set; }
        }

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
