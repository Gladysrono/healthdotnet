using FluentValidation;

namespace newhealthdotnet.Application.Authentication.CommandsAndQueris.Commands.ForgotPassword
{
    public class ForgetPasswordCommandValidator : AbstractValidator<ForgetPasswordCommand>
    {
        public ForgetPasswordCommandValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("Valid email is required");
        }
    }
}
