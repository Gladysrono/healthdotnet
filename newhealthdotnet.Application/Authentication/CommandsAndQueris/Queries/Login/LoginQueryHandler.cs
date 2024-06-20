using MediatR;
using newhealthdiotnet.Contracts.Authentication;
using newhealthdotnet.Infrastructure.Authentication;
using newhealthdotnet.Infrastructure.Authentication.Repositories;

namespace newhealthdotnet.Application.Authentication.CommandsAndQueris.Queries.Login
{
    public class LoginUserCommandHandler(IUserRepository userRepository, JwtTokenGenerator jwtTokenGenerator) : IRequestHandler<LoginUserCommand, AuthenticationResponse>
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly JwtTokenGenerator _jwtTokenGenerator = jwtTokenGenerator;

        public async Task<AuthenticationResponse> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByEmailAsync(request.Email);
            if (!(user != null && BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash)))
            {
                throw new Exception("Invalid credentials");
            }

            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResponse { Token = token };
        }
    }
}
