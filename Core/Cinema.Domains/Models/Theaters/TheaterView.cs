namespace Cinema.Domains.Models.Theaters;

public class TheaterView
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public SeatModel[] Seats { get; set; }
}