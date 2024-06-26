﻿using FluentValidation;

namespace newhealthdotnet.Application.Authentication.CommandsAndQueris.Commands.ResetPassword
{
    public class ResetPasswordCommandValidator : AbstractValidator<ResetPasswordCommand>
    {
        public ResetPasswordCommandValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("Valid email is required");
            RuleFor(x => x.Token).NotEmpty().WithMessage("Token is required");
            RuleFor(x => x.NewPassword).NotEmpty().WithMessage("New password is required");
        }
    }
}
