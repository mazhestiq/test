using Cinema.Domains.Entities.Base;
using Cinema.Domains.Enums;

namespace Cinema.Domains.Entities;

public class Movie : AuditEntity
{
    public string Title { get; set; }

    public string Description { get; set; }

    public int Duration { get; set; }

    public GenreType Genre { get; set; }
}