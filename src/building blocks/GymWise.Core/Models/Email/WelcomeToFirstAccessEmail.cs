namespace GymWise.Core.Models.Email
{
    public sealed record WelcomeToFirstAccessEmail
    {
        public WelcomeToFirstAccessEmail(string emailTo, string name, string temporaryPassword)
        {
            EmailTo = emailTo;
            Name = name;
            TemporaryPassword = temporaryPassword;
        }

        public string EmailTo { get; init; }
        public string Name { get; init; }
        public string TemporaryPassword { get; init; }
    }
}
