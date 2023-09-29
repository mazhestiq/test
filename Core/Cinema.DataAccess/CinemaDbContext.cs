using Cinema.DataAccess.Configurations;
using Cinema.DataAccess.Seeds;
using Cinema.Domains.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cinema.DataAccess
{
    public class CinemaDbContext : DbContext
    {
        public CinemaDbContext(DbContextOptions<CinemaDbContext> options)
            : base(options)
        {
        }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ConfigureShowTimeSeat();

        }

        public DbSet<Theater> Theaters { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ShowTime> ShowTimes { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        
    }
}