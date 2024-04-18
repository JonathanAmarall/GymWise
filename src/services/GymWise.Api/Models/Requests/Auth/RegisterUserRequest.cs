namespace GymWise.Api.Models.Requests.Auth
{
    public record RegisterUserRequest
    {
        public string ConfirmPassword { get; init; }
        public string Password { get; init; }
        public string UserName { get; init; }
        public string Email { get; init; }
        public string PhoneNumber { get; init; }
    }
}
