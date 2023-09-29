namespace Cinema.Domains.Models.Reservations;

public class ShowTimeView
{
    public Guid Id { get; set; }

    public Guid TheaterId { get; set; }
    public Guid MovieId { get; set; }
    public DateTime ShowTimeAt { get; set; }

}