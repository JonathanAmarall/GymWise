using System.ComponentModel.DataAnnotations;

namespace GymWise.Api.Models.Requests.Auth
{
    public record AuthenticateUserRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; init; }
        [Required]
        public string Password { get; init; }
    }
}
