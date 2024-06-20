using MediatR;
using newhealthdiotnet.Contracts.Authentication;

namespace newhealthdotnet.Application.Authentication.CommandsAndQueris.Queries.Login
{
    public class LoginUserCommand : IRequest<AuthenticationResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
