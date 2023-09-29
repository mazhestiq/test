namespace Cinema.Domains.Models.ShowTimes;

public class SeatView
{
    public Guid Id { get; set; }
    public int Row { get; set; }
    public int Place { get; set; }
}