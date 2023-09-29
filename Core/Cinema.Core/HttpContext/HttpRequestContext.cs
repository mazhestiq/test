using Cinema.Core.HttpFilters.Models;
using Cinema.Core.Logging;
using Microsoft.AspNetCore.Http;

namespace Cinema.Core.HttpContext
{
    public class HttpRequestContext : BaseRequestContext
    {
        public HttpRequestContext(IHttpContextAccessor httpContextAccessor)
        {
            RequestId = Guid.NewGuid();
        }

        public void AddErrorLevel(ErrorLevel errorLevel)
        {
            if (Errors == null)
            {
                Errors = new BaseErrorObject();
            }

            Errors.ErrorLevel = errorLevel;
        }

        public void AddFingerprint(ActionFingerprint actionFingerprint)
        {
            if (Errors == null)
            {
                Errors = new BaseErrorObject();
            }

            Errors.ActionFingerprint = actionFingerprint;
        }
    }
}