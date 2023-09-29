using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Cinema.Core.HttpContext
{
    public class HttpRequestContextProvider : IRequestContextProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HttpRequestContextProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public IRequestContext Context => _httpContextAccessor?.HttpContext?.RequestServices?.GetService<IRequestContext>()??new RequestContext()
        {
            RequestId = Guid.Empty,
        };
    }

    public class RequestContext : IRequestContext
    {
        public Guid RequestId { get; set; }
    }
}