namespace GymWise.Api.Models.Requests.Auth
{
    public record AuthenticateUserRequest
    {
        public string Email { get; init; }
        public string Password { get; init; }
    }
}
