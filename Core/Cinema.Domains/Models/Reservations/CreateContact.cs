using Cinema.Core.Extensions;
using System.ComponentModel.DataAnnotations;

namespace Cinema.Domains.Models.Reservations;

public class CreateContact : IValidatableObject
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (string.IsNullOrWhiteSpace(FirstName))
            yield return new ValidationResult($"{nameof(FirstName)} is empty.");

        if (string.IsNullOrWhiteSpace(LastName))
            yield return new ValidationResult($"{nameof(LastName)} is empty.");

        if (Email.IsValidEmail())
            yield return new ValidationResult($"{nameof(Email)} is empty.");

        if (string.IsNullOrWhiteSpace(Phone))
            yield return new ValidationResult($"{nameof(Phone)} is empty.");
    }
}