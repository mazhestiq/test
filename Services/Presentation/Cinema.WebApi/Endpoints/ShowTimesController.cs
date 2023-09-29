using AutoMapper;
using Cinema.Core.HttpContext;
using Cinema.Domains.Entities;
using Cinema.Domains.Models.ShowTimes;
using Cinema.Service.Contracts.Services;
using Cinema.WebApi.Endpoints.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.WebApi.Endpoints;

[Route("api/v1/[controller]")]
public class ShowTimesController : BaseController
{
    private readonly IShowTimeService _showTimeService;

    public ShowTimesController(IMapper mapper, IRequestContext requestContextProvider, IShowTimeService showTimeService) :
        base(mapper, requestContextProvider)
    {
        _showTimeService = showTimeService;
    }

    [HttpGet("{showTimeId}")]
    [ProducesResponseType(typeof(ShowTimeView), StatusCodes.Status200OK)]
    public async Task<IActionResult> Create([FromRoute] Guid showTimeId)
    {
        var data = await _showTimeService.GetAsync(showTimeId, new [] { $"{nameof(ShowTime.Seats)}.{nameof(ShowTimeSeat.Seat)}" });

        var result = Mapper.Map<ShowTimeView>(data);

        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
    public async Task<IActionResult> Create([FromBody] CreateShowTime request)
    {
        var data = Mapper.Map<ShowTime>(request);

        var newShowTime = await _showTimeService.CreateAsync(data);

        return Ok(newShowTime.Id);
    }
}