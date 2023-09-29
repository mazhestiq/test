using Cinema.Domains.Entities.Base;

namespace Cinema.Domains.Entities;

public class Theater : AuditEntity
{
    public string Name { get; set; }

    public ICollection<Seat> Seats { get; set; }
}