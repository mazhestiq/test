using System.ComponentModel.DataAnnotations;

namespace Cinema.Domains.Models.ShowTimes;

public class ShowTimeSeatModel : IValidatableObject
{
    public Guid SeatId { get; set; }
    public decimal Price { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (Price <= 0)
            yield return new ValidationResult($"{nameof(Price)} must be greater than 0.");
    }
}