using AutoMapper;
using NetflixApi.Application.Abstractions.Messaging;
using NetflixApi.Application.Users.GetUser;
using NetflixApi.Domain.Abstractions;
using NetflixApi.Domain.Users;
using NetflixApi.Domain.WatchHistories;
using Serilog;

namespace NetflixApi.Application.WatchHistories.GetUserWatchHistories;

internal sealed class GetUserWatchHistoriesQueryHandler : IQueryHandler<GetUserWatchHistoriesQuery, ICollection<UserWatchHistoriesResponse>>
{
    private readonly IWatchHistoryRepository _watchHistoryRepository;
    private readonly IMapper _mapper;

    public GetUserWatchHistoriesQueryHandler(
        IWatchHistoryRepository watchHistoryRepository,
        IMapper mapper)
    {
        _watchHistoryRepository = watchHistoryRepository;
        _mapper = mapper;
    }
    public async Task<Result<ICollection<UserWatchHistoriesResponse>>> Handle(GetUserWatchHistoriesQuery request, CancellationToken cancellationToken)
    {
        Log.Information("Getting User with Id {Id}", request);

        var result = await _watchHistoryRepository.GetUsersWatchHistories(request.userId, cancellationToken);

        if (result != null)
        {
            var response = _mapper.Map<ICollection<UserWatchHistoriesResponse>>(result);
            return Result.Success<ICollection<UserWatchHistoriesResponse>>(response);
        }
        else
        {
            Log.Information("User with Id {Id} does not exists", request);
            return Result.Failure<ICollection<UserWatchHistoriesResponse>>(UserErrors.NotFound);
        }
    }
}
