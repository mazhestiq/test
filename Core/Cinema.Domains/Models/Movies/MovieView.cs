using Cinema.Domains.Enums;

namespace Cinema.Domains.Models.Movies
{
    public class MovieView
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int Duration { get; set; }

        public GenreType Genre { get; set; }
    }
}
