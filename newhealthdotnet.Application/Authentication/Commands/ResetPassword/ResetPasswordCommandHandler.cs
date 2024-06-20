using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using newhealthdiotnet.Contracts.Authentication;
using newhealthdotnet.Application.Commands;
using newhealthdotnet.Domain.Entities.UserManagement;
using newhealthdotnet.Infrastructure.Authentication;
using newhealthdotnet.Infrastructure.Authentication.Repositories;

namespace newhealthdotnet.Application.Handlers
{
    public class ResetPasswordCommandHandler(IUserRepository userRepository, JwtTokenGenerator jwtTokenGenerator) : IRequestHandler<ResetPasswordCommand, AuthenticationResponse>
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly JwtTokenGenerator _jwtTokenGenerator = jwtTokenGenerator;

        public async Task<AuthenticationResponse> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByEmailAsync(request.Email);
            if (user == null)
            {
                throw new Exception("User does not exist");
            }

            if (!ValidateToken(request.Token, user))
            {
                throw new Exception("Invalid or expired token");
            }

            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.NewPassword);
            user.ResetPasswordToken = null; // Invalidate the token
            user.ResetPasswordTokenExpiry = null; // Invalidate the token expiry
            await _userRepository.UpdateUserAsync(user);

            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResponse { Token = token };
        }

        private bool ValidateToken(string token, User user)
        {
            if (user.ResetPasswordToken != token || user.ResetPasswordTokenExpiry < DateTime.UtcNow)
            {
                return false;
            }
            return true;
        }
    }
}
