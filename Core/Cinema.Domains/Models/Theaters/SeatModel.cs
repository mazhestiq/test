using System.ComponentModel.DataAnnotations;

namespace Cinema.Domains.Models.Theaters;

public class SeatModel
{
    public Guid? Id { get; set; }

    [Range(0, int.MaxValue)]
    public int Row { get; set; }

    [Range(0, int.MaxValue)]
    public int Place { get; set; }
}