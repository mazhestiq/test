using Cinema.Core.HttpContext;
using Cinema.Core.HttpFilters.Models;
using Cinema.Core.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace Cinema.Core.Extensions
{
    public static class FilterContextExtensions
    {
        public static Guid GetRequestId(this FilterContext context) => GetHttpRequestContext(context).RequestId;

        public static BaseErrorObject GetErrors(this FilterContext context) => GetHttpRequestContext(context).Errors;

        public static FilterContext AddErrorMessage(this FilterContext context, string errorMessage)
        {
            GetHttpRequestContext(context).AddError(errorMessage);
            return context;
        }
        
        public static FilterContext AddErrorException(this FilterContext context, Exception exception)
        {
            var httpContext = GetHttpRequestContext(context);

            if (exception?.Message != null)
                httpContext.AddError($"Exception: {exception?.Message}");

            if (exception?.InnerException?.Message != null)
                httpContext.AddError($"InnerException: {exception?.InnerException?.Message}");

            return context;
        }

        public static FilterContext AddErrorLevel(this FilterContext context, ErrorLevel errorLevel)
        {
            GetHttpRequestContext(context).AddErrorLevel(errorLevel);
            return context;
        }

        public static FilterContext AddFingerprint(this FilterContext context, ActionFingerprint actionFingerprint)
        {
            GetHttpRequestContext(context).AddFingerprint(actionFingerprint);
            return context;
        }

        public static HttpRequestContext GetHttpRequestContext(FilterContext context)
        {
            return (HttpRequestContext)context.HttpContext.RequestServices.GetService<IRequestContextProvider>().Context;
        }
    }
}
