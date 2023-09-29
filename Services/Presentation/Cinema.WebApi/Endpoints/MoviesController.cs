using AutoMapper;
using Cinema.Core.HttpContext;
using Cinema.Domains.Entities;
using Cinema.Domains.Models.Movies;
using Cinema.Service.Contracts.Services;
using Cinema.WebApi.Endpoints.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.WebApi.Endpoints;

[Route("api/v1/[controller]")]
public class MoviesController : BaseController
{
    private readonly IMovieService _movieService;

    public MoviesController(IMapper mapper, IRequestContext requestContextProvider, IMovieService movieService) : base(mapper, requestContextProvider)
    {
        _movieService = movieService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(MovieView[]), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var movies = await _movieService.QueryAsync();

        var result = Mapper.Map<MovieView[]>(movies);

        return Ok(result);
    }

    [HttpGet("{movieId}")]
    [ProducesResponseType(typeof(MovieView), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get([FromRoute] Guid movieId)
    {
        var movie = await _movieService.GetAsync(movieId);

        var result = Mapper.Map<MovieView>(movie);

        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(MovieView), StatusCodes.Status200OK)]
    public async Task<IActionResult> Add([FromBody] CreateMovie request)
    {
        var data = Mapper.Map<Movie>(request);

        var newMovie = await _movieService.CreateAsync(data);

        var result = Mapper.Map<MovieView>(newMovie);

        return Ok(result);
    }

    [HttpPut]
    [ProducesResponseType(typeof(OkResult), StatusCodes.Status200OK)]
    public async Task<IActionResult> Update([FromBody] UpdateMovie request)
    {
        var data = Mapper.Map<Movie>(request);

        await _movieService.UpdateAsync(data);

        return Ok();
    }

    [HttpDelete("{movieId}")]
    [ProducesResponseType(typeof(OkResult), StatusCodes.Status200OK)]
    public async Task<IActionResult> Delete([FromRoute] Guid movieId)
    {
        await _movieService.DeleteAsync(movieId);

        return Ok();
    }
}