namespace GymWise.Api.Models.Requests.Workouts
{
    public record CreateSetsRequest
    {
        public short Reps { get; init; }
        public short Series { get; init; }
        public short? IntervalsInSeconds { get; init; }
        public short? Weight { get; init; }
        public string? AdvancedTechnique { get; init; }
        public Guid ExerciseId { get; init; }
    }
}
