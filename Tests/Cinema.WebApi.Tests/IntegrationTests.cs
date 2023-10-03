using System.Net.Http.Json;
using Cinema.Core.HttpFilters.Models;
using Cinema.DataBase.Contracts.Services;
using Cinema.Domains.Entities;
using Cinema.Domains.Enums;
using Cinema.Domains.Models.Movies;
using Cinema.Domains.Models.Reservations;
using Cinema.Domains.Models.ShowTimes;
using Cinema.Domains.Models.Theaters;
using Cinema.Service.Contracts.Services;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Xunit.Extensions.AssemblyFixture;

namespace Cinema.WebApi.Tests;

public class IntegrationTests : IClassFixture<ServerFixture>
{
    private readonly HttpClient _client;
    private readonly TestServer _testServer;

    public IntegrationTests(ServerFixture server)
    {
        _testServer = server.TestServer;
        _client = server.TestServer.CreateClient();
    }

    [Fact]
    public async Task Create_New_Movie()
    {
        // Arrange
        var newMovie = new CreateMovie
        {
            Title = "test movie",
            Description = "test movie decription",
            Duration = 60,
            Genre = GenreType.Western
        };

        // Act
        var result = await _client.PostAsJsonAsync($"/api/v1/Movies", newMovie);

        // Assert
        result.EnsureSuccessStatusCode();

        var content = await result.Content.ReadAsStringAsync();
        var movie = JsonConvert.DeserializeObject<BaseResultObject<MovieView>>(content);

        Assert.NotNull(movie);
        Assert.Equal(newMovie.Title, movie.Payload.Title);
    }

    [Fact]
    public async Task Receive_All_movies()
    {
        // Arrange


        // Act
        var response = await _client.GetAsync($"/api/v1/Movies");

        // Assert
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        var movies = JsonConvert.DeserializeObject<BaseResultObject<MovieView[]>>(content);

        Assert.NotNull(movies);
        Assert.NotEmpty(movies.Payload);
    }

    [Fact]
    public async Task Create_New_Theater()
    {
        // Arrange
        var newTheater = new CreateTheater
        {
            Name = "Test theater",
            Seats = new SeatModel[]
            {
                new ()
                {
                    Row = 0,
                    Place = 0
                },
                new ()
                {
                    Row = 1,
                    Place = 1
                },new ()
                {
                    Row = 2,
                    Place = 2
                }

            }
        };

        // Act
        var result = await _client.PostAsJsonAsync($"/api/v1/Theaters", newTheater);

        // Assert
        result.EnsureSuccessStatusCode();

        var content = await result.Content.ReadAsStringAsync();
        var theater = JsonConvert.DeserializeObject<BaseResultObject<TheaterView>>(content);

        Assert.NotNull(theater);
        Assert.Equal(newTheater.Name, theater.Payload.Name);
    }

    [Fact]
    public async Task Create_New_ShowTime()
    {
        // Arrange
        var movie = (await _testServer.Services.GetService<IMovieRepository>().QueryAsync()).FirstOrDefault();
        var theater = (await _testServer.Services.GetService<ITheaterRepository>().QueryAsync()).FirstOrDefault();
        var seat = (await _testServer.Services.GetService<ISeatRepository>().GetAsync(new Guid("0d609517-72c3-4bc1-90dc-acbfbd395311")));

        var showTime = new CreateShowTime
        {
            ShowTimeAt = new DateTime(2030, 10, 15, 10, 0, 0),
            MovieId = movie.Id,
            Seats = new ShowTimeSeatModel[]
            {
                new()
                {
                    SeatId = seat.Id,
                    Price = 100
                }
            },
            TheaterId = theater.Id
        };

        // Act
        var result = await _client.PostAsJsonAsync($"/api/v1/ShowTimes", showTime);

        // Assert
        result.EnsureSuccessStatusCode();

        var content = await result.Content.ReadAsStringAsync();
        var newShowTime = JsonConvert.DeserializeObject<BaseResultObject<Guid>>(content);

        Assert.NotNull(showTime);
        Assert.IsType<Guid>(newShowTime.Payload);
    }

    [Fact]
    public async Task Create_New_Reservation()
    {
        // Arrange
        var showTime = (await _testServer.Services.GetService<IShowTimeRepository>().QueryAsync()).FirstOrDefault();
        var seat = (await _testServer.Services.GetService<ISeatRepository>().GetAsync(new Guid("0d609517-72c3-4bc1-90dc-acbfbd395311")));

        var reservation = new CreateReservation
        {
            SeatId = seat.Id,
            ShowTimeId = showTime.Id,
            Contact = new CreateContact
            {
                Email = "test email",
                FirstName = "test",
                LastName = "test",
                Phone = "+12345"
            }
        };

        // Act
        var result = await _client.PostAsJsonAsync($"/api/v1/Reservations", reservation);

        // Assert
        var content = await result.Content.ReadAsStringAsync();
        var newReservation = JsonConvert.DeserializeObject<BaseResultObject<Guid>>(content);

        Assert.NotNull(newReservation);
        Assert.IsType<Guid>(newReservation.Payload);
    }

    [Fact]
    public async Task Confirm_Existing_Reservation()
    {
        var showTime = (await _testServer.Services.GetService<IShowTimeRepository>().QueryAsync()).FirstOrDefault();
        var seat = (await _testServer.Services.GetService<ISeatRepository>().GetAsync(new Guid("0d609517-72c3-4bc1-90dc-acbfbd395311")));

        var reservation = new Reservation
        {
            SeatId = seat.Id,
            ShowTimeId = showTime.Id,
            Contact = new Contact
            {
                Email = "test email",
                FirstName = "test",
                LastName = "test",
                Phone = "+12345"
            }
        };

        var newReservation = await _testServer.Services.GetService<IReservationService>().CreateAsync(reservation);

        // Arrange
        var reservationId = newReservation.Id;

        // Act
        await _client.PutAsJsonAsync($"/api/v1/Reservations/{reservationId}/confirm", reservationId);

        var result = await _client.GetAsync($"/api/v1/Reservations/{reservationId}");
        // Assert
        result.EnsureSuccessStatusCode();

        var content = await result.Content.ReadAsStringAsync();
        var confirmedReservation = JsonConvert.DeserializeObject<BaseResultObject<ReservationView>>(content);

        Assert.NotNull(confirmedReservation);
        Assert.True(confirmedReservation.Payload.IsConfirmed);
    }


    [Fact]
    public async Task Receive_All_theaters()
    {
        // Arrange


        // Act
        var response = await _client.GetAsync($"/api/v1/Theaters");

        // Assert
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        var theaters = JsonConvert.DeserializeObject<BaseResultObject<TheaterView[]>>(content);

        Assert.NotNull(theaters);
        Assert.NotEmpty(theaters.Payload);
    }
}