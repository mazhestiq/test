﻿using Cinema.Domains.Enums;
using System.ComponentModel.DataAnnotations;

namespace Cinema.Domains.Models.Movies;

public class UpdateMovie : IValidatableObject
{
    public Guid Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public int Duration { get; set; }

    public GenreType Genre { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (string.IsNullOrWhiteSpace(Title))
            yield return new ValidationResult($"{nameof(Title)} is empty.");

        if (string.IsNullOrWhiteSpace(Description))
            yield return new ValidationResult($"{nameof(Description)} is empty.");

        if (Enumerable.Range(1, 300).Contains(Duration))
            yield return new ValidationResult($"{nameof(Duration)} not in range between 0 and 300.");
    }
}