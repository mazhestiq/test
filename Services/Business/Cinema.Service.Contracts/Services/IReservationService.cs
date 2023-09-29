using Cinema.Domains.Entities;
using Cinema.Service.Contracts.Services.Base;

namespace Cinema.Service.Contracts.Services;

public interface IReservationService : ICrudService<Reservation>
{
    Task Confirm(Guid reservationId);
}