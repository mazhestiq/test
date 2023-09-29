using Cinema.DataAccess;
using Cinema.DataBase.Contracts.Services;
using Cinema.DataContracts.Contracts;
using Cinema.Domains.Entities;
using Cinema.Service.Contracts.Services;
using Cinema.Service.Implementation.Services.Base;

namespace Cinema.Service.Implementation.Services;

public class ShowTimeService : BaseCrudService<ShowTime, IShowTimeRepository, CinemaDbContext>, IShowTimeService
{
    private readonly ISeatRepository _seatRepository;
    public ShowTimeService(IUnitOfWorkFactory<CinemaDbContext> unitOfWorkFactory, IShowTimeRepository repository, ISeatRepository seatRepository) : base(unitOfWorkFactory, repository)
    {
        _seatRepository = seatRepository;
    }

    public override async Task<ShowTime> CreateAsync(ShowTime showTime)
    {
        var seats = (await _seatRepository.QueryAsync(t=>t.TheaterId == showTime.TheaterId));

        var notAllowedSeats = showTime.Seats.Select(t => t.SeatId).ToArray().Except(seats.Select(t => t.Id).ToArray()).ToArray();

        if (notAllowedSeats.Any())
            throw new ArgumentException($"Seats {string.Join(',', notAllowedSeats)} not in theater {showTime.TheaterId} or unavailable anymore");
        
        return await base.CreateAsync(showTime);
    }
}