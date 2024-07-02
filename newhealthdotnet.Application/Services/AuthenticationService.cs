

using newhealthdiotnet.Contracts.Authentication;
using newhealthdotnet.Application.Interfaces;
using newhealthdotnet.Domain.Entities.UserManagement;
using newhealthdotnet.Infrastructure.Authentication;
using newhealthdotnet.Infrastructure.Repositories;

namespace newhealthdotnet.Application.Services
{
    public class AuthenticationService(IUserRepository userRepository,
                                     //  JwtTokenGenerator jwtTokenGenerator,
                                      // IEmailSender emailSender
                                     //  ITokenGenerator tokenGenerator) : IAuthenticationService
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly JwtTokenGenerator _jwtTokenGenerator = jwtTokenGenerator;

        //public IEmailSender EmailSender { get; } = emailSender;

        private readonly IEmailSender _emailSender = emailSender;
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
