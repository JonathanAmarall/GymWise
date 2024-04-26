using System.ComponentModel.DataAnnotations;

namespace GymWise.Api.Models.Requests.Auth
{
    public record RegisterUserRequest
    {
        [Required]
        public string ConfirmPassword { get; init; }
        [Required]
        public string Password { get; init; }
        [Required]
        public string UserName { get; init; }
        [Required]
        [EmailAddress]
        public string Email { get; init; }
        [Required]
        public string PhoneNumber { get; init; }
    }
}
