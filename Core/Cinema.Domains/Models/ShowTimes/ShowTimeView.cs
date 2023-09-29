namespace Cinema.Domains.Models.ShowTimes;

public class ShowTimeView
{
    public Guid Id { get; set; }

    public Guid TheaterId { get; set; }
    public Guid MovieId { get; set; }
    public DateTime ShowTimeAt { get; set; }

    public SeatView[] Seats { get; set; }
}