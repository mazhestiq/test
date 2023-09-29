using Cinema.Domains.Entities.Base;

namespace Cinema.Domains.Entities;

public class Seat : AuditEntity
{
    public Guid TheaterId { get; set; }
    public Theater Theater { get; set; }

    public int Row { get; set; }
    public int Place { get; set; }

    public ICollection<ShowTimeSeat> ShowTimes { get; set; }
}