using Cinema.Domains.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cinema.DataAccess.Configurations
{
    public static class ShowTimeSeatConfigure
    {
        public static void ConfigureShowTimeSeat(this ModelBuilder builder)
        {
            builder.Entity<ShowTimeSeat>()
                .HasKey(t => new { t.ShowTimeId, t.SeatId});

            builder.Entity<ShowTimeSeat>()
                .HasOne(t => t.Seat)
                .WithMany(t => t.ShowTimes)
                .HasForeignKey(t => t.SeatId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<ShowTimeSeat>()
                .HasOne(t => t.ShowTime)
                .WithMany(t => t.Seats)
                .HasForeignKey(t => t.ShowTimeId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
