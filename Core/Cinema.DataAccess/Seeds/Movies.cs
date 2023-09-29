using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinema.Domains.Entities;
using Cinema.Domains.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cinema.DataAccess.Seeds
{
    public static class Movies
    {
        public static void AddMovies(this CinemaDbContext db)
        {
            var data = new Movie[]
            {
                new()
                {
                    Id = new Guid("e9e176b0-5960-4084-8ad2-ae0d7a08b076"),
                    Title = "test movie",
                    Description = "test movie decription",
                    Duration = 60,
                    Genre = GenreType.Western
                }
            };

            if (!db.Movies.Any())
            {
                db.Movies.AddRange(data);
            }

            db.SaveChanges();
        }
    }
}
