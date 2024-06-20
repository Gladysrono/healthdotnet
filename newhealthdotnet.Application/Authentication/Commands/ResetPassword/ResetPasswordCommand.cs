using MediatR;
using newhealthdiotnet.Contracts.Authentication;

namespace newhealthdotnet.Application.Commands
{
    public class ResetPasswordCommand : IRequest<AuthenticationResponse>
    {
        public string Email { get; set; }
        public string Token { get; set; }
        public string NewPassword { get; set; }
    }
}
