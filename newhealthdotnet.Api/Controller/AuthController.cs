using Microsoft.AspNetCore.Mvc;
using newhealthdotnet.Application.Interfaces;
using newhealthdiotnet.Contracts.Authentication;

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
    }
}
