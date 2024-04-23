using System.ComponentModel.DataAnnotations;

namespace GymWise.Api.Models.Requests.Students
{
    public record CreateStudentRequest
    {
        private const int DocumentMaxLength = 18;

        [Required]
        [MinLength(3)]
        public string FirstName { get; init; }
        [Required]
        [MinLength(3)]
        public string LastName { get; init; }
        [Required]
        public string UserName { get; init; }
        [Required]
        [EmailAddress]
        public string Email { get; init; }
        [Phone]
        [Required]
        public string PhoneNumber { get; init; }
        [Required]
        public DateTime DateOfBirth { get; init; }
        [Required]
        [MaxLength(length: DocumentMaxLength)]
        /// <summary>
        /// **Use CPF or CNPJ value**
        /// </summary>
        public string Document { get; init; }
    }
}
