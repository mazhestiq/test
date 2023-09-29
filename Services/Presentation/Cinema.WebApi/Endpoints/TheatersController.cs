using AutoMapper;
using Cinema.Core.HttpContext;
using Cinema.Domains.Entities;
using Cinema.Domains.Models.Theaters;
using Cinema.Service.Contracts.Services;
using Cinema.WebApi.Endpoints.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.WebApi.Endpoints;

[Route("api/v1/[controller]")]
public class TheatersController : BaseController
{
    private readonly ITheaterService _theaterService;

    public TheatersController(IMapper mapper, IRequestContext requestContextProvider, ITheaterService theaterService) : base(mapper, requestContextProvider)
    {
        _theaterService = theaterService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(TheaterView[]), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var theaters = await _theaterService.QueryAsync(t => t.Seats);

        var result = Mapper.Map<TheaterView[]>(theaters);

        return Ok(result);
    }

    [HttpGet("{theaterId}")]
    [ProducesResponseType(typeof(TheaterView), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get([FromRoute] Guid theaterId)
    {
        var theater = await _theaterService.GetAsync(theaterId, t => t.Seats);

        var result = Mapper.Map<TheaterView>(theater);

        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
    public async Task<IActionResult> Add([FromBody] CreateTheater request)
    {
        var data = Mapper.Map<Theater>(request);

        var newTheater = await _theaterService.CreateAsync(data);

        var result = Mapper.Map<TheaterView>(newTheater);

        return Ok(result);
    }

    [HttpPut]
    [ProducesResponseType(typeof(OkResult), StatusCodes.Status200OK)]
    public async Task<IActionResult> Update([FromBody] UpdateTheater request)
    {
        var existing = await _theaterService.GetAsync(request.Id, t => t.Seats);

        var data = Mapper.Map(request, existing);

        await _theaterService.UpdateAsync(data);

        return Ok();
    }

    [HttpDelete("{theaterId}")]
    [ProducesResponseType(typeof(OkResult), StatusCodes.Status200OK)]
    public async Task<IActionResult> Delete([FromRoute] Guid theaterId)
    {
        await _theaterService.DeleteAsync(theaterId);

        return Ok();
    }

}