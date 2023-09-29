using Cinema.Core.Extensions;
using Cinema.Core.HttpFilters.Models;
using Cinema.Core.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Cinema.Core.HttpFilters
{
    public class BadRequestResultHandlingFilter : ResultFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            if (context.Result is BadRequestObjectResult || context.Result is BadRequestResult)
            {
                context
                    .AddErrorLevel(ErrorLevel.Warning)
                    .AddFingerprint(ActionFingerprint.BadRequestWarning);

                context.Result = new BadRequestObjectResult(new BaseResultObject<object>
                {
                    RequestId = context.GetRequestId(),
                    TimeStamp = DateTime.UtcNow,
                    Errors = context.GetErrors()
                });
            }
        }
    }
}