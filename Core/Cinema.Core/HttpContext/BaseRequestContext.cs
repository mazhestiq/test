using Cinema.Core.Extensions;
using Cinema.Core.HttpFilters.Models;
using Newtonsoft.Json.Linq;

namespace Cinema.Core.HttpContext
{
    public abstract class BaseRequestContext : IRequestContext
    {
        public Guid RequestId { get; protected set; }


        public BaseErrorObject Errors { get; protected set; }


        public void AddError(string errorMessage)
        {
            if (Errors == null)
            {
                Errors = new BaseErrorObject();
            }

            if (Errors.Messages.IsNullOrEmpty())
            {
                Errors.Messages = new List<string>();
            }

            if (!errorMessage.IsEmptyString())
            {
                Errors.Messages.Add(errorMessage);
            }
        }
    }
}