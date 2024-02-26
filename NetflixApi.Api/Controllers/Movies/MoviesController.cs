using MediatR;
using Microsoft.AspNetCore.Mvc;
using NetflixApi.Api.Models;
using NetflixApi.Application.Movies.AddMovie;
using NetflixApi.Application.Movies.GetMovies;
using NetflixApi.Application.TVShows.AddTVShow;
using NetflixApi.Application.TVShows.GetTVShow;
using Serilog;

namespace NetflixApi.Api.Controllers.Movies;

public class MoviesController : APIControllerBase
{
    private readonly ISender _sender;
    private readonly ApplicationState _applicationState;

    public MoviesController(ISender sender, ApplicationState applicationState)
    {
        _sender = sender;
        _applicationState = applicationState;
    }

    [HttpGet("{movieId}")]
    public async Task<IActionResult> GetMovie(
        int movieId,
        CancellationToken cancellationToken)
    {
        try
        {
            var query = new GetMovieQuery(movieId);

            var result = await _sender.Send(query, cancellationToken);

            if (result.Value == null)
            {
                return NotFound($"TVShow with ID: {movieId} no found.");
            }
            return Ok(result.Value);
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Error while trying to TVShow");
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddMovie(
        AddMovieRequest request,
        CancellationToken cancellationToken)
    {
        try
        {
            var command = new AddMovieCommand(request);

            var result = await _sender.Send(command, cancellationToken);
            if (result != null)
            {
                return Created($"{_applicationState.BaseUrl}/api/Movies/{result.Value}", result.Value);
            }

            return BadRequest();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Error while trying to AddMovie");
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("many")]
    public async Task<IActionResult> AddMovies(
        List<AddMovieRequest> requests,
        CancellationToken cancellationToken)
    {
        try
        {
            foreach (var request in requests)
            {
                var command = new AddMovieCommand(request);

                var result = await _sender.Send(command, cancellationToken);
            }

            return Ok();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Error while trying to AddMovie");
            return BadRequest(ex.Message);
        }
    }
}
