using Cinema.Domains.Entities.Base;

namespace Cinema.Domains.Entities;

public class Reservation : AuditEntity
{
    public Guid ShowTimeId { get; set; }
    public ShowTime ShowTime { get; set; }

    public Guid SeatId { get; set; }
    public Seat Seat { get; set; }

    public Guid ContactId { get; set; }
    public Contact Contact { get; set; }

    public bool IsConfirmed { get; set; }
    public DateTime? ConfirmedAt { get; set; } 
}