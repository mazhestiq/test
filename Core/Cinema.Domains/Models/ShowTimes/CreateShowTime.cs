using System.ComponentModel.DataAnnotations;

namespace Cinema.Domains.Models.ShowTimes
{

    public class CreateShowTime : IValidatableObject
    {
        public Guid TheaterId { get; set; }
        public Guid MovieId { get; set; }

        public DateTime ShowTimeAt { get; set; }

        public ShowTimeSeatModel[] Seats { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (ShowTimeAt < DateTime.Now)
                yield return new ValidationResult($"{nameof(ShowTimeAt)} can't be less than datetime now.");
        }
    }
}
