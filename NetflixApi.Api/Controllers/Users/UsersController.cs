using MediatR;
using Microsoft.AspNetCore.Mvc;
using NetflixApi.Api.Models;
using NetflixApi.Application.Users.AddUser;
using NetflixApi.Application.Users.GetUser;
using NetflixApi.Application.WatchHistories.AddWatchHistory;
using NetflixApi.Application.WatchHistories.GetUserWatchHistories;
using Serilog;

namespace NetflixApi.Api.Controllers.Users;

public class UsersController : APIControllerBase
{
    private readonly ISender _sender;
    private readonly ApplicationState _applicationState;

    public UsersController(ISender sender, ApplicationState applicationState)
    {
        _sender = sender;
        _applicationState = applicationState;
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetUser(
        int userId,
        CancellationToken cancellationToken)
    {
        try
        {
            var query = new GetUserQuery(userId);

            var result = await _sender.Send(query, cancellationToken);

            if (result.Value == null)
            {
                return NotFound($"User with ID: {userId} no found.");
            }
            return Ok(result.Value);
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Error while trying to get User.");
            return BadRequest(ex.Message);
        }

    }

    [HttpPost]
    public async Task<IActionResult> AddUser(
        AddUserRequest request,
        CancellationToken cancellationToken)
    {
        try
        {
            var command = new AddUserCommand(request);

            var result = await _sender.Send(command, cancellationToken);
            if (result != null)
            {
                return Created($"{_applicationState.BaseUrl}/api/User/{result.Value}", result.Value);
            }

            return BadRequest();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Error while trying to add User.");
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("many")]
    public async Task<IActionResult> AddUsers(
        List<AddUserRequest> requests,
        CancellationToken cancellationToken)
    {
        try
        {
            foreach (var request in requests)
            {
                var command = new AddUserCommand(request);

                var result = await _sender.Send(command, cancellationToken);
            }

            return Ok();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Error while trying to User.");
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("watch")]
    public async Task<IActionResult> AddMovieHistory(
        AddWatchHistoryRequest request,
        CancellationToken cancellationToken)
    {
        try
        {
            var command = new AddWatchHistoryCommand(request);

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
    [HttpGet("{userId}/watch")]
    public async Task<IActionResult> GetUserWatchHistory(
        int userId,
        CancellationToken cancellationToken)
    {
        try
        {
            var query = new GetUserWatchHistoriesQuery(userId);

            var result = await _sender.Send(query, cancellationToken);

            if (result.Value == null)
            {
                return NotFound($"User with ID: {userId} no found.");
            }
            return Ok(result.Value);
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Error while trying to get User.");
            return BadRequest(ex.Message);
        }

    }
}
