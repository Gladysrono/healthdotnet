using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using newhealthdiotnet.Contracts.Authentication;
using newhealthdotnet.Domain.Entities;
using newhealthdotnet.Domain.Entities.UserManagement;
using newhealthdotnet.Infrastructure.Authentication;
using newhealthdotnet.Infrastructure.Authentication.Repositories;

//namespace to be provided
namespace newhealthdotnet.Application.Authentication.CommandsAndQueris.Commands.Register
{
    public class RegisterUserCommandHandler(IUserRepository userRepository, JwtTokenGenerator jwtTokenGenerator) : IRequestHandler<RegisterUserCommand, AuthenticationResponse>
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly JwtTokenGenerator _jwtTokenGenerator = jwtTokenGenerator;

        public async Task<AuthenticationResponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
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

            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResponse { Token = token };
        }
    }
}
