using Cinema.Core.Exceptions;
using Cinema.Core.Extensions;
using Cinema.Core.HttpFilters.Models;
using Cinema.Core.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Cinema.Core.HttpFilters
{
    public class ErrorHandlingFilter : ExceptionFilterAttribute
    {
        private readonly ILogger _logger;

        public ErrorHandlingFilter(ILogger logger)
        {
            _logger = logger;
        }

        public override void OnException(ExceptionContext context)
        {
            var exceptionType = context.Exception.GetType();


            if (exceptionType != typeof(BadRequestException))
                _logger.LogCritical(context.Exception, "Application Error");

            context
                .AddErrorException(context.Exception)
                .AddErrorLevel(ErrorLevel.Error)
                .AddFingerprint(GetFingerPrint(exceptionType, context.Exception));

            var result = new BadRequestObjectResult(new BaseResultObject<object>()
            {
                RequestId = context.GetRequestId(),
                TimeStamp = DateTime.UtcNow,
                Errors = context.GetErrors()
            });

            context.ExceptionHandled = true;
            context.Result = result;
        }

        private static ActionFingerprint GetFingerPrint(Type exceptionType, Exception exception)
        {
            if (exceptionType == typeof(BadRequestException))
                return ActionFingerprint.BadRequestWarning;
            
            return exceptionType == typeof(ConverterException)
                ? ActionFingerprint.ConverterError
                : ActionFingerprint.ApplicationError;
        }
    }
}
