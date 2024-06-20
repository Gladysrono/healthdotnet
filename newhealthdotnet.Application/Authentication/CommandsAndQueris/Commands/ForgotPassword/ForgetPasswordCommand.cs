using MediatR;

namespace newhealthdotnet.Application.Authentication.CommandsAndQueris.Commands.ForgotPassword
{
    public class ForgetPasswordCommand : IRequest
    {
        public string Email { get; set; }
    }
}
