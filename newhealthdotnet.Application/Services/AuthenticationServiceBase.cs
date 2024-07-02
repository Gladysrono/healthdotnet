using newhealthdiotnet.Contracts.Authentication;
using newhealthdotnet.Domain.Entities.UserManagement;

namespace newhealthdotnet.Application.Services
{
    public class AuthenticationServiceBase
    {

        public async Task<AuthenticationResponse> LoginAsync(LoginRequest request)
        {
            var user = await _userRepository.GetUserByEmailAsync(request.Email);
            if (!(user != null && BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash)))
            {
                throw new Exception("Invalid credentials");
            }

            // var token = _jwtTokenGenerator.GenerateToken(user);

            //  return new AuthenticationResponse { Token = token };
        }
        // private readonly ITokenGenerator _tokenGenerator = tokenGenerator;

        public async Task<AuthenticationResponse> RegisterAsync(RegisterRequest request)
        {
            var existingUser = await _userRepository.GetUserByEmailAsync(request.Email);
            if (existingUser != null)
            {
                throw new Exception("User already exists");
            }

            var user = new User
            {
                Id = Guid.NewGuid(),
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
                ResetPasswordToken = string.Empty, // Initialize required member
                ResetPasswordTokenExpiry = null
            };

            await _userRepository.AddUserAsync(user);

            //var token = _jwtTokenGenerator.GenerateToken(user);

            //return new AuthenticationResponse { Token = token };
        }
    }
}