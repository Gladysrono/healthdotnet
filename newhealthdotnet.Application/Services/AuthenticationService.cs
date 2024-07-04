using System;
using System.Threading.Tasks;
using newhealthdiotnet.Contracts.Authentication;
using newhealthdotnet.Application.Interfaces;
using newhealthdotnet.Domain.Entities.UserManagement;
using newhealthdotnet.Infrastructure.Authentication;
using newhealthdotnet.Infrastructure.Repositories;

namespace newhealthdotnet.Application.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly JwtTokenGenerator _jwtTokenGenerator;
        private readonly IEmailSender _emailSender;

        public AuthenticationService(IUserRepository userRepository, JwtTokenGenerator jwtTokenGenerator, IEmailSender emailSender)
        {
            _userRepository = userRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
            _emailSender = emailSender;
        }

        public async Task<AuthenticationResponse> RegisterAsync(RegisterRequest request)
        {
            // Implement registration logic here
            throw new NotImplementedException();
        }

        public async Task<AuthenticationResponse> LoginAsync(LoginRequest request)
        {
            // Implement login logic here
            throw new NotImplementedException();
        }

        public async Task ForgetPasswordAsync(ForgetPassword request)
        {
            var user = await _userRepository.GetUserByEmailAsync(request.Email);
            if (user == null)
            {
                throw new Exception("User does not exist");
            }

            var resetToken = _jwtTokenGenerator.GenerateToken(user);
            await _emailSender.SendResetPasswordEmailAsync(user.Email, resetToken);
        }

        public async Task ResetPasswordAsync(ResetPassword request)
        {
            var user = await _userRepository.GetUserByEmailAsync(request.Email);
            if (user == null)
            {
                throw new Exception("User does not exist");
            }

            if (!ValidateToken(request.Token, user)) // Implement the token validation logic here
            {
                throw new Exception("Invalid or expired token");
            }

            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.NewPassword);
            await _userRepository.UpdateUserAsync(user);
        }

        private bool ValidateToken(string token, User user)
        {
            // Add your token validation logic here
            return true; // Placeholder for actual token validation
        }
    }
}
