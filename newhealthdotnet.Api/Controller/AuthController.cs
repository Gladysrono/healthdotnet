// AuthController.cs
using Microsoft.AspNetCore.Mvc;
using newhealthdotnet.Application.Interfaces;
using newhealthdiotnet.Contracts.Authentication;
using System.Threading.Tasks;

namespace newhealthdotnet.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var result = await _authenticationService.RegisterAsync(request);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var result = await _authenticationService.LoginAsync(request);
            return Ok(result);
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgetPassword request)
        {
            await _authenticationService.ForgetPasswordAsync(request);
            return Ok(new { Message = "Password reset token sent to email" });
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPassword request)
        {
            await _authenticationService.ResetPasswordAsync(request);
            return Ok(new { Message = "Password has been reset successfully" });
        }
    }
}
