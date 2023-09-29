using System.ComponentModel.DataAnnotations;

namespace Cinema.Domains.Models.Theaters
{
    public class CreateTheater : IValidatableObject
    {
        public string Name { get; set; }

        public SeatModel[] Seats { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(string.IsNullOrWhiteSpace(Name))
                yield return new ValidationResult($"{nameof(Name)} is empty.");

            if (!Seats.Any())
                yield return new ValidationResult($"{nameof(Seats)} is empty.");

            var duplicates = Seats.GroupBy(t => new { t.Row, t.Place }).Where(t => t.Count() > 1).ToArray();

            if (duplicates.Any())
            {
                yield return new ValidationResult(
                    $"Seats {string.Join(',', duplicates.Select(t => $"(Row {t.Key.Row}, Place {t.Key.Place})").ToArray())} present more than once.");
            }
        }
    }
}
