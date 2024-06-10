
using MediatR;
using newhealthdiotnet.Contracts.Authentication;

namespace newhealthdotnet.Application.Commands
{
    public class RegisterUserCommand : IRequest<AuthenticationResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
