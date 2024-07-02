

using newhealthdiotnet.Contracts.Authentication;
using newhealthdotnet.Application.Interfaces;
using newhealthdotnet.Domain.Entities.UserManagement;
using newhealthdotnet.Infrastructure.Authentication;
using newhealthdotnet.Infrastructure.Repositories;

namespace newhealthdotnet.Application.Services
{
    public class AuthenticationService(IUserRepository userRepository,: AuthenticationServiceBase

    //  JwtTokenGenerator jwtTokenGenerator,
    // IEmailSender emailSender
    //  ITokenGenerator tokenGenerator) : IAuthenticationService
    {
        private static IEmailSender emailSender;
        private readonly IUserRepository _userRepository = userRepository;
        private readonly JwtTokenGenerator _jwtTokenGenerator = jwtTokenGenerator;

        //public IEmailSender EmailSender { get; } = emailSender;

        private readonly IEmailSender _emailSender = emailSender;

        public static JwtTokenGenerator jwtTokenGenerator { get; private set; }

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
