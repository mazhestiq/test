using Cinema.Domains.Entities.Base;

namespace Cinema.Domains.Entities;

public class ShowTime : AuditEntity
{
    public Guid MovieId { get; set; }
    public Movie Movie { get; set; }

    public Guid TheaterId { get; set; }
    public Theater Theater { get; set; }

    public DateTime ShowTimeAt { get; set; }

    public ICollection<ShowTimeSeat> Seats { get; set; }
}