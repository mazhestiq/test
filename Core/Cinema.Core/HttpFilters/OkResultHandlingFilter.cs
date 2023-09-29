using Cinema.Core.Extensions;
using Cinema.Core.HttpFilters.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Cinema.Core.HttpFilters
{
    public class OkResultHandlingFilter : ResultFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            try
            {
                if (context.Result is OkObjectResult okObjectResult)
                {
                    context.Result = new OkObjectResult(new BaseResultObject<object>()
                    {
                        RequestId = context.GetRequestId(),
                        TimeStamp = DateTime.UtcNow,
                        Payload = okObjectResult.Value,
                    });
                }
                else if (context.Result is OkResult objectResult)
                {
                    context.Result = new OkObjectResult(new BaseResultObject<object>()
                    {
                        RequestId = context.GetRequestId(),
                        TimeStamp = DateTime.UtcNow
                    });
                }
            }
            catch (Exception e)
            {
                context.Result = new BadRequestObjectResult(e.ToString());
            }
            
        }
    }
}