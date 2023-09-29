namespace Cinema.Domains.Models.Reservations
{
    public class CreateReservation
    {
        public Guid ShowTimeId { get; set; }

        public Guid SeatId { get; set; }

        public CreateContact Contact { get; set; }
    }
}
