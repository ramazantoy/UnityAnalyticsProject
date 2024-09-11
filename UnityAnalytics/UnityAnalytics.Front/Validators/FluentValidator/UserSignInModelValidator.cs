using FluentValidation;
using UnityAnalytics.Front.Models;

namespace UnityAnalytics.Front.Validators.FluentValidator;

public class UserSignInModelValidator : AbstractValidator<UserSignInModel>
{
    public UserSignInModelValidator()
    {
        RuleFor(x => x.UserName).NotEmpty().WithMessage("*Username is required").Length(5, 20)
            .WithMessage("*Username must be between 5 and 20 characters");
        
        RuleFor(x => x.Password).NotEmpty().WithMessage("*Password is required").MinimumLength(6)
            .WithMessage("*Password must be at least 6 characters long.")
            .MaximumLength(20).WithMessage("*Password cannot be longer than 20 characters.");
    }
}

