namespace Cinema.Domains.Entities;

public class ShowTimeSeat
{
    public Guid ShowTimeId { get; set; }
    public ShowTime ShowTime { get; set; }

    public Guid SeatId { get; set; }
    public Seat Seat { get; set; }

    public decimal Price { get; set; }
}