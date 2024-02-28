using NetflixApi.Application.Abstractions.Messaging;
using NetflixApi.Application.Movies.MovieHistories.AddWatchHistory;
using NetflixApi.Domain.Abstractions;
using NetflixApi.Domain.Movies.MovieHistories;
using NetflixApi.Domain.Users;
using NetflixApi.Domain.WatchHistories;
using Serilog;

namespace NetflixApi.Application.WatchHistories.AddWatchHistory;

internal sealed class AddWatchHistoryCommandHandler : ICommandHandler<AddWatchHistoryCommand, int>
{
    private readonly IWatchHistoryRepository _watchHistoryRepository;
    private readonly IUserRepository _userRepository;

    public AddWatchHistoryCommandHandler(
        IWatchHistoryRepository watchHistoryRepository,
        IUserRepository userRepository)
    {
        _watchHistoryRepository = watchHistoryRepository;
        _userRepository = userRepository;
    }
    public async Task<Result<int>> Handle(AddWatchHistoryCommand command, CancellationToken cancellationToken)
    {

        var user = await _userRepository.GetByIdAsync(command.request.UserId);

        if (user != null)
        {
            var watchHistory = new WatchHistory(
            command.request.UserId,
            command.request.ShowId,
            command.request.Type
            );

            Log.Information("Adding watchHistory with Id {Id}", watchHistory.Id);


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

