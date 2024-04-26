namespace GymWise.Api.Configuration
{
    public record TokenConfiguration
    {
        public static string SectionName = "TokenConfiguration";
        public string Secret { get; init; }
        public string Issuer { get; init; }
        public string ValidIn { get; init; }
        public short ExpiresHours { get; init; }
    }
}
