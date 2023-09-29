using AutoMapper;
using Cinema.Core.HttpContext;
using Cinema.Domains.Entities;
using Cinema.Domains.Models.Reservations;
using Cinema.Service.Contracts.Services;
using Cinema.WebApi.Endpoints.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.WebApi.Endpoints;

[Route("api/v1/[controller]")]
public class ReservationsController : BaseController
{
    private readonly IReservationService _reservationService;

    public ReservationsController(IMapper mapper, IRequestContext requestContextProvider, IReservationService reservationService) : base(mapper, requestContextProvider)
    {
        _reservationService = reservationService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
    public async Task<IActionResult> ReserveSeat([FromBody] CreateReservation request)
    {
        var data = Mapper.Map<Reservation>(request);

        var newReservation = await _reservationService.CreateAsync(data);

        return Ok(newReservation.Id);
    }

    [HttpPut("{reservationId}/confirm")]
    [ProducesResponseType(typeof(OkResult), StatusCodes.Status200OK)]
    public async Task<IActionResult> ConfirmSeat([FromRoute] Guid reservationId)
    {
        await _reservationService.Confirm(reservationId);

        return Ok();
    }

    [HttpGet("{reservationId}")]
    [ProducesResponseType(typeof(ReservationView), StatusCodes.Status200OK)]
    public async Task<IActionResult> BookingDetails([FromRoute] Guid reservationId)
    {
        var data = await _reservationService.GetAsync(reservationId, t => t.ShowTime, t => t.Seat, t => t.Contact);

        var result = Mapper.Map<ReservationView>(data);

        return Ok(result);
    }
}