using GymWise.Api.Models;
using GymWise.Api.Models.Requests.Auth;
using GymWise.Api.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GymWise.Api.Controllers
{
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : MainController
    {
        private readonly ITokenService _tokenService;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public AuthController(IMediator mediator, ITokenService tokenService, UserManager<User> userManager, SignInManager<User> signInManager) : base(mediator)
        {
            _tokenService = tokenService;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("authenticate")]
        public async Task<ActionResult> Authenticate(AuthenticateUserRequest model)
        {
            if (!ModelState.IsValid) return CustomReponse(ModelState);

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                AddProcessingError("Email or password invalid.");
                return CustomReponse();
            }

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);

            if (result.Succeeded)
            {
                var token = await _tokenService.GenerateTokenJwtAsync(user);
                await _signInManager.SignInAsync(user, false);
                return CustomReponse(new
                {
                    token,
                    user.UserName,
                    user.Email,
                });
            }

            AddProcessingError("Email or password is invalid.");
            return CustomReponse();
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterUserRequest request)
        {
            if (request.ConfirmPassword != request.Password)
            {
                AddProcessingError("Password and ConfirmPassowrd does not match.");
                return CustomReponse();
            }

            var newUser = new User(request.UserName, request.Email, request.PhoneNumber);

            var result = await _userManager.CreateAsync(newUser, request.Password);

            if (result.Succeeded)
            {
                var tokenJwt = await _tokenService.GenerateTokenJwtAsync(newUser);

                return CustomReponse(new
                {
                    tokenJwt,
                    newUser.UserName,
                    newUser.Email,
                });
            }

            foreach (var error in result.Errors)
            {
                AddProcessingError(error.Code, error.Description);
            }

            return CustomReponse();
        }
    }
}
