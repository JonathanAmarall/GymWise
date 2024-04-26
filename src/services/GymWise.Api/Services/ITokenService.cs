using GymWise.Api.Models;

namespace GymWise.Api.Services
{
    public interface ITokenService
    {
        Task<string> GenerateTokenJwtAsync(User user);
    }
}
