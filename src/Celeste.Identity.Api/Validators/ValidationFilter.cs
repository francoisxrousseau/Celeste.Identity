namespace Celeste.Identity.Api.Validators;

using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

/// <summary>
///     Validation filter that validates incoming requests using FluentValidation.
///     All request models and parameters are validated here before reaching the controller action.
/// </summary>
public class ValidationFilter : IAsyncActionFilter
{
    /// <summary>
    ///     Validates the incoming request model or parameters.
    /// </summary>
    /// <param name="context"></param>
    /// <param name="next"></param>
    /// <returns></returns>
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var validatorType = typeof(IValidator<>)
            .MakeGenericType(context.ActionDescriptor.Parameters.First().ParameterType);

        if (context.HttpContext.RequestServices.GetService(validatorType) is IValidator validator)
        {
            var model = context.ActionArguments.Values.FirstOrDefault();
            if (model != null)
            {
                var validationContext = new ValidationContext<object>(model);
                var result = await validator.ValidateAsync(validationContext);

                if (!result.IsValid)
                {
                    context.Result = new BadRequestObjectResult(result.Errors);
                    return;
                }
            }
        }

        await next();
    }
}
