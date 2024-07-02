using newhealthdiotnet.Contracts.Authentication;
using newhealthdotnet.Domain.Entities.UserManagement;
using newhealthdotnet.Infrastructure.Repositories;

namespace newhealthdotnet.Application.Services
{
    public class AuthenticationServiceBaseBase
    {
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

            await IUserRepository.AddUserAsync(user);

            //var token = _jwtTokenGenerator.GenerateToken(user);

            //return new AuthenticationResponse { Token = token };
        }
    }
}