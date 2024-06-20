using Microsoft.AspNetCore.Mvc;
using newhealthdotnet.Application.Interfaces;
using newhealthdiotnet.Contracts.Authentication;
using Microsoft.AspNetCore.Identity.Data;
using LoginRequest = newhealthdiotnet.Contracts.Authentication.LoginRequest;
using RegisterRequest = newhealthdiotnet.Contracts.Authentication.RegisterRequest;

namespace newhealthdotnet.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(IAuthenticationService authenticationService) : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService = authenticationService;

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var result = await _authenticationService.RegisterAsync(request);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var result = await _authenticationService.LoginAsync(request);
            return Ok(result);
        }
        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword(ForgetPassword request)
        {
            await _authenticationService.ForgetPasswordAsync(request);
            return Ok(new { Message = "Password reset token sent to email" });
        }
        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPassword request)
        {
            await _authenticationService.ResetPasswordAsync(request);
            return Ok(new { Message = "Password has been reset successfully" });
        }


    }
}
