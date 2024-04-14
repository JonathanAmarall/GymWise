namespace GymWise.Workout.Application.Workouts.Commands.CreateWorkoutAndSetsCommand
{
    public record CreateSetsCommand
    {
        public CreateSetsCommand(short reps, short series, short? intervalsInSeconds, short? weight, string? advancedTechnique, Guid exerciseId)
        {
            Reps = reps;
            Series = series;
            IntervalsInSeconds = intervalsInSeconds;
            Weight = weight;
            AdvancedTechnique = advancedTechnique;
            ExerciseId = exerciseId;
        }

        public short Reps { get; init; }
        public short Series { get; init; }
        public short? IntervalsInSeconds { get; init; }
        public short? Weight { get; init; }
        public string? AdvancedTechnique { get; init; }
        public Guid ExerciseId { get; init; }
    }
}
