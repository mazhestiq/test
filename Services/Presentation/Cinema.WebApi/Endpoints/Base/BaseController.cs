using AutoMapper;
using Cinema.Core.HttpContext;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.WebApi.Endpoints.Base
{
    public class BaseController : ControllerBase
    {
        protected readonly IMapper Mapper;
        protected readonly IRequestContext RequestContextProvider;

        public BaseController(IMapper mapper, IRequestContext requestContextProvider):base()
        {
            Mapper = mapper;
            RequestContextProvider = requestContextProvider;
        }
    }
}
