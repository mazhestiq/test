namespace Cinema.Domains.Models.Reservations;

public class ReservationView
{
    public Guid Id { get; set; }

    public ShowTimeView ShowTime { get; set; }

    public SeatView Seat { get; set; }

    public ContactView Contact { get; set; }

    public bool IsConfirmed { get; set; }
    public DateTime? ConfirmedAt { get; set; }
}