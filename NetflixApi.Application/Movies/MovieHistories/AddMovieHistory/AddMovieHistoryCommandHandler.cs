using NetflixApi.Application.Abstractions.Messaging;
using NetflixApi.Domain.Abstractions;
using NetflixApi.Domain.Movies.MovieHistories;
using NetflixApi.Domain.Users;
using Serilog;

namespace NetflixApi.Application.Movies.MovieHistories.AddWatchHistory;
internal sealed class AddMovieHistoryCommandHandler : ICommandHandler<AddMovieHistoryCommand, int>
{
    private readonly IMovieHistoryRepository _watchHistoryRepository;
    private readonly IUserRepository _userRepository;

    public AddMovieHistoryCommandHandler(
        IMovieHistoryRepository watchHistoryRepository,
        IUserRepository userRepository)
    {
        _watchHistoryRepository = watchHistoryRepository;
        _userRepository = userRepository;
    }
    public async Task<Result<int>> Handle(AddMovieHistoryCommand command, CancellationToken cancellationToken)
    {
        Log.Information("Adding watchHistory with Id {Id}", command.request.UserId);

        var user = await _userRepository.GetByIdAsync(command.request.UserId);

        if (user != null)
        {
            var watchHistory = new MovieHistory(
            command.request.UserId,
            command.request.MovieId
            );

            await _watchHistoryRepository.Add(watchHistory);

            return watchHistory.UserId;
        }
        else
        {
            Log.Information("User with Id {Id} does not exists", command.request.UserId);
            return Result.Failure<int>(BaseErrors.NotFound);
        }
    }
}
