using Cinema.Domains.Entities;

namespace Cinema.DataAccess.Seeds;

public static class Theaters
{
    public static void AddTheaters(this CinemaDbContext db)
    {
        var data = new Theater[]
        {
            new()
            {
                Id = new Guid("96b885b9-a395-47c0-aabe-04ef14cfa8fa"),
                Name = "Test Theater",
                Seats = new List<Seat>
                {
                    new ()
                    {
                        Id = new Guid("69afb28b-196f-4546-8668-db6b191e963f"),
                        Row = 0,
                        Place = 0
                    },
                    new ()
                    {
                        Id = new Guid("0d609517-72c3-4bc1-90dc-acbfbd395311"),
                        Row = 1,
                        Place = 1
                    },new ()
                    {
                        Id = new Guid("31c53347-8c83-4083-a908-576567c946d3"),
                        Row = 2,
                        Place = 2
                    }

                }
            }
        };

        if (!db.Theaters.Any())
        {
            db.Theaters.AddRange(data);
        }

        db.SaveChanges();
    }
}

public static class ShowTimes
{
    public static void AddShowTimes(this CinemaDbContext db)
    {
        var data = new ShowTime[]
        {
            new()
            {
                Id = new Guid("fb0d9209-2ea4-46ce-b228-32788115b28b"),
                TheaterId = new Guid("96b885b9-a395-47c0-aabe-04ef14cfa8fa"),
                MovieId =  new Guid("e9e176b0-5960-4084-8ad2-ae0d7a08b076"),
                ShowTimeAt = new DateTime(2023, 10, 11, 10, 30, 00),
                Seats = new List<ShowTimeSeat>
                {
                    new()
                    {
                        SeatId = new Guid("0d609517-72c3-4bc1-90dc-acbfbd395311")
                    },
                    new()
                    {
                        SeatId = new Guid("69afb28b-196f-4546-8668-db6b191e963f")
                    }
                }
            }
        };

        if (!db.ShowTimes.Any())
        {
            db.ShowTimes.AddRange(data);
        }

        db.SaveChanges();
    }
}