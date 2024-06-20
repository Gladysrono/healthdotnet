using MediatR;
using newhealthdiotnet.Contracts.Authentication;

namespace newhealthdotnet.Application.Authentication.CommandsAndQueris.Commands.ResetPassword
{
    public class ResetPasswordCommand : IRequest<AuthenticationResponse>
    {
        public string Email { get; set; }
        public string Token { get; set; }
        public string NewPassword { get; set; }
    }
}
