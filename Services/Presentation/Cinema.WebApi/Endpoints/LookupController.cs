using AutoMapper;
using Cinema.Core.HttpContext;
using Cinema.Domains.Models;
using Cinema.Service.Contracts.Services;
using Cinema.WebApi.Endpoints.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.WebApi.Endpoints
{
    [Route("api/v1/[controller]")]
    public class LookupController : BaseController
    {
        public LookupController(IMapper mapper, IRequestContext requestContextProvider) : base(mapper, requestContextProvider)
        {
            
        }

        /// <summary>
        /// Retrieves a lookup for enums and some dictionaries. 
        /// </summary>
        /// <remarks>Not case sensitive. Possible values: GenreType
        /// </remarks>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Dictionary<string, List<LookUpModel>>))]
        public async Task<IActionResult> GetEntities(string entities, [FromServices] IDataTableFilterService dictionaryResolver)
        {
            if (string.IsNullOrEmpty(entities))
            {
                return Ok();
            }
            var result = await dictionaryResolver.GetEntities(HttpContext.RequestServices, entities.Split(","));

            return Ok(result);
        }
    }
}