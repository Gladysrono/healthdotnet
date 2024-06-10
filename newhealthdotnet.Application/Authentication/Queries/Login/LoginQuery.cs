using MediatR;
using newhealthdiotnet.Contracts.Authentication;

namespace newhealthdotnet.Application.Commands
{
    public class LoginUserCommand : IRequest<AuthenticationResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
