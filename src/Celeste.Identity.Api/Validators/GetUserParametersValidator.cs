namespace Celeste.Identity.Api.Validators;

using Celeste.Identity.Common.Parameters;
using FluentValidation;

/// <summary>
///     Validator for <see cref="GetUserParameters"/>.
/// </summary>
public class GetUserParametersValidator : AbstractValidator<GetUserParameters>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="GetUserParametersValidator"/> class.
    /// </summary>
    public GetUserParametersValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("UserId must not be empty.");
    }
}
