using Microsoft.AspNetCore.Identity;

namespace GymWise.Api.Models
{
    public class User : IdentityUser<Guid>
    {
        public User(string userName, string email, string phoneNumber) :
            base(userName: userName)
        {
            Email = email;
            PhoneNumber = phoneNumber;
            UserName = userName;
        }
    }
}
