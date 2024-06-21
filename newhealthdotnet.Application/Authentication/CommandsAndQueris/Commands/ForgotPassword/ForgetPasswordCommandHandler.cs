using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using newhealthdotnet.Infrastructure.Authentication;
using newhealthdotnet.Infrastructure.Repositories;

namespace newhealthdotnet.Application.Authentication.CommandsAndQueris.Commands.ForgotPassword
{
    public class ForgetPasswordCommandHandler : IRequest<ForgetPasswordCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmailSender _emailSender;
        private readonly ITokenGenerator _tokenGenerator;

        public ForgetPasswordCommandHandler(IUserRepository userRepository, IEmailSender emailSender, ITokenGenerator tokenGenerator)
        {
            _userRepository = userRepository;
            _emailSender = emailSender;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<Unit> Handle(ForgetPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByEmailAsync(request.Email);
            if (user == null)
            {
                throw new Exception("User does not exist");
            }

            var resetToken = _tokenGenerator.GenerateToken(user);
            await _emailSender.SendResetPasswordEmailAsync(user.Email, resetToken);

            return Unit.Value;
        }
    }
}
