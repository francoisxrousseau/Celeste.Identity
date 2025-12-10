namespace Celeste.Identity.Api.Validators;

using Celeste.Identity.Common.Parameters;
using FluentValidation;

/// <summary>
///     Validator for <see cref="DeleteUserParameters"/>.
/// </summary>
public class DeleteUserParametersValidator : AbstractValidator<DeleteUserParameters>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="DeleteUserParametersValidator"/> class.
    /// </summary>
    public DeleteUserParametersValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("UserId must not be empty.");
    }
}
