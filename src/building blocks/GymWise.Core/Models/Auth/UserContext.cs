using GymWise.Core.Contracts.Authentication;
using Microsoft.AspNetCore.Http;

namespace GymWise.Core.Models.Auth
{
    public sealed class UserContext : IUserContext
    {
        public UserContext(IHttpContextAccessor httpContextAccessor)
        {
            string userIdClaim = httpContextAccessor.HttpContext?.User?.FindFirst("sub")?.Value
                ?? throw new ArgumentException("The user identifier claim is required.", nameof(httpContextAccessor));

            UserId = new Guid(userIdClaim);
        }

        public Guid UserId { get; }
    }
}
