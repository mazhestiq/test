using System.ComponentModel.DataAnnotations;
using Cinema.Core.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Cinema.Core.HttpFilters
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        private readonly ILogger _logger;

        public ValidateModelAttribute(ILogger logger)
        {
            _logger = logger;
        }

        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            foreach (var actionArgument in actionContext.ActionArguments)
            {
                if (actionArgument.Value is IValidatableObject validationObj)
                {
                    validationObj.Validate(new ValidationContext(validationObj)).Select(t =>
                    {
                        actionContext.AddErrorMessage(t.ErrorMessage);
                        return t;
                    }).ToArray();
                }
                else if (actionArgument.Value is IValidatableObject[] validationObjArray)
                {
                    foreach (var validationItem in validationObjArray)
                    {
                        validationItem.Validate(new ValidationContext(validationItem)).Select(t =>
                        {
                            actionContext.AddErrorMessage(t.ErrorMessage);
                            return t;
                        }).ToArray();
                    }
                }
            }

            if (!actionContext.ModelState.IsValid)
            {
                actionContext.ModelState.Values.SelectMany(t=>t.Errors).Select(t =>
                {
                    actionContext.AddErrorMessage(t.ErrorMessage);
                    return t;
                }).ToArray();
            }

            if (actionContext.GetErrors()?.Messages.Any() != null)
            {
                actionContext.Result = new BadRequestResult();
            }
        }
    }
}