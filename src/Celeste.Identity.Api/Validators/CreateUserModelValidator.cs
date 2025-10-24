namespace Celeste.Identity.Api.Validators;

using Celeste.Identity.Common.Models;
using FluentValidation;

/// <summary>
///     Validator for <see cref="CreateUserModel"/>.
/// </summary>
public class CreateUserModelValidator : AbstractValidator<CreateUserModel>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="GetUserParametersValidator"/> class.
    /// </summary>
    public CreateUserModelValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email address is required")
            .EmailAddress().WithMessage("A valid email is required");

        RuleFor(x => x.UserName)
            .NotEmpty().WithMessage("User name is required")
            .MinimumLength(3).WithMessage("User name must be at least 3 characters long")
            .MaximumLength(50).WithMessage("User name must not exceed 30 characters");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required")
            .MinimumLength(3).WithMessage("UPassword must be at least 5 characters long")
            .MaximumLength(50).WithMessage("Password must not exceed 50 characters")
            .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
            .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter.")
            .Matches("[0-9]").WithMessage("Password must contain at least one digit character.");
    }
}
