using MediatR;
using Microsoft.AspNetCore.Mvc;
using NetflixApi.Api.Models;
using NetflixApi.Application.TVShows.AddTVShow;
using NetflixApi.Application.TVShows.GetTVShow;
using Serilog;

namespace NetflixApi.Api.Controllers.TVShows;

public class TVShowsController: APIControllerBase
{
    private readonly ISender _sender;
    private readonly ApplicationState _applicationState;

    public TVShowsController(ISender sender, ApplicationState applicationState)
    {
        _sender = sender;
        _applicationState = applicationState;
    }

    [HttpGet("{tvShowId}")]
    public async Task<IActionResult> GetTVShow(
        int tvShowId,
        CancellationToken cancellationToken)
    {
        try
        {
            var query = new GetTVShowQuery(tvShowId);

            var result = await _sender.Send(query, cancellationToken);

            if (result.Value == null)
            {
                return NotFound($"TVShow with ID: {tvShowId} no found.");
            }
            return Ok(result.Value);
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Error while trying to get TVShow");
            return BadRequest(ex.Message);
        }

    }

    [HttpPost]
    public async Task<IActionResult> AddTVShow(
        AddTVShowRequest request,
        CancellationToken cancellationToken)
    {
        try
        {
            var command = new AddTVShowCommand(request);

            var result = await _sender.Send(command, cancellationToken);
            if (result != null)
            {
                return Created($"{_applicationState.BaseUrl}/api/TVShows/{result.Value}", result.Value);
            }

            return BadRequest();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Error while trying to add TVShow.");
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("many")]
    public async Task<IActionResult> AddTVShows(
        List<AddTVShowRequest> requests,
        CancellationToken cancellationToken)
    {
        try
        {
            foreach (var request in requests)
            {
                var command = new AddTVShowCommand(request);

                var result = await _sender.Send(command, cancellationToken);
            }

            return Ok();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Error while trying to add TVShow.");
            return BadRequest(ex.Message);
        }
    }
}
