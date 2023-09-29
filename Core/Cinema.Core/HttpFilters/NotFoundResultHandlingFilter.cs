using Cinema.Core.Extensions;
using Cinema.Core.HttpFilters.Models;
using Cinema.Core.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Cinema.Core.HttpFilters
{
    public class NotFoundResultHandlingFilter : ResultFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            if (context.Result is NotFoundResult objectResult)
            {
                context
                    .AddErrorLevel(ErrorLevel.Warning)
                    .AddFingerprint(ActionFingerprint.NotFoundWarning);

                context.Result = new NotFoundObjectResult(new BaseResultObject<object>()
                {
                    RequestId = context.GetRequestId(),
                    TimeStamp = DateTime.UtcNow,
                    Errors = context.GetErrors()
                });
            }
        }
    }
}