using MediatR;

namespace newhealthdotnet.Application.Commands
{
    public class ForgetPasswordCommand : IRequest
    {
        public string Email { get; set; }
    }
}
