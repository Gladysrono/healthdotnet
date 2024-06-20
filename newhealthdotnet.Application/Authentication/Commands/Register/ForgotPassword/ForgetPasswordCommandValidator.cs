using FluentValidation;
using newhealthdotnet.Application.Commands;

namespace newhealthdotnet.Application.Validators
{
    public class ForgetPasswordCommandValidator : AbstractValidator<ForgetPasswordCommand>
    {
        public ForgetPasswordCommandValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("Valid email is required");
        }
    }
}
