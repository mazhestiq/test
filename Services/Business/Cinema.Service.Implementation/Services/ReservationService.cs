﻿using Cinema.Core.Configs;
using Cinema.Core.Exceptions;
using Cinema.DataAccess;
using Cinema.DataAccess.Seeds;
using Cinema.DataBase.Contracts.Services;
using Cinema.DataBase.Implementation.Services;
using Cinema.DataContracts.Contracts;
using Cinema.Domains.Entities;
using Cinema.Service.Contracts.Services;
using Cinema.Service.Implementation.Services.Base;

namespace Cinema.Service.Implementation.Services;

public class ReservationService : BaseCrudService<Reservation, IReservationRepository, CinemaDbContext>, IReservationService
{
    private readonly IShowTimeSeatRepository _showTimeSeatRepository;
    private readonly ReservationSettings _reservationSettings;

    public ReservationService(IUnitOfWorkFactory<CinemaDbContext> unitOfWorkFactory, IReservationRepository repository, ReservationSettings reservationSettings, IShowTimeSeatRepository showTimeSeatRepository) : base(unitOfWorkFactory, repository)
    {
        _reservationSettings = reservationSettings;
        _showTimeSeatRepository = showTimeSeatRepository;
    }

    public override async Task<Reservation> CreateAsync(Reservation newReservation)
    {
        var showTimeSeat = _showTimeSeatRepository.QueryAsync(t => t.ShowTimeId == newReservation.ShowTimeId && t.SeatId == newReservation.SeatId).FirstOrDefault();

        if (showTimeSeat == null)
            throw new ArgumentException($"Seat {newReservation.SeatId} not present in showtime.");

        var occupiedSeat = await QueryAsync(t =>
            t.ShowTimeId == newReservation.ShowTimeId && 
            t.SeatId == newReservation.SeatId && 
            (t.IsConfirmed || (!t.IsConfirmed && t.CreatedAt < DateTime.Now.AddMinutes(-_reservationSettings.ReservationTimeout))));

        if (occupiedSeat.FirstOrDefault() != null)
            throw new AlreadyExistsException($"Seat {newReservation.SeatId} already booked.");

        newReservation.Price = showTimeSeat.Price;
        
        return await base.CreateAsync(newReservation);
    }

    public async Task Confirm(Guid reservationId)
    {
        var reservation = await GetAsync(reservationId);

        if(reservation.IsConfirmed)
            return;

        if (!reservation.IsConfirmed && reservation.CreatedAt < DateTime.Now.AddMinutes(-_reservationSettings.ReservationTimeout))
            throw new ArgumentException($"Reservation {reservationId} is expired please create new one. Sorry for that, but you have only {_reservationSettings.ReservationTimeout} min to confirm.");

        reservation.IsConfirmed = true;
        reservation.ConfirmedAt = DateTime.Now;

        await UpdateAsync(reservation);
    }
}