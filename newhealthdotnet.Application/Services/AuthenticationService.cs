using newhealthdiotnet.Contracts.Authentication;
using newhealthdotnet.Application.Interfaces;
using newhealthdotnet.Domain.Entities;
using newhealthdotnet.Infrastructure.Authentication;
using newhealthdotnet.Infrastructure.Repositories;
namespace newhealthdotnet.Application.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly JwtTokenGenerator _JwtTokenGenerator;//basically injecting jwtTokengenerator using constrctor

        public AuthenticationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
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
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password)
            };
            
            await _userRepository.AddUserAsync(user);

            
            var token = _JwtTokenGenerator.GenerateToken(user);//calling the method from jwttokengenerator class

            return new AuthenticationResponse { Token = token };
        }

        public async Task<AuthenticationResponse> LoginAsync(LoginRequest request)
        {
            var user = await _userRepository.GetUserByEmailAsync(request.Email);
            if (!(user != null && BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash)))
            {
                throw new Exception("Invalid credentials");
            }

            // Generate JWT token
            var token = _JwtTokenGenerator.GenerateToken(user);//calling the method from jwttokengenerator class

            return new AuthenticationResponse { Token = token };
        }
    }
}
