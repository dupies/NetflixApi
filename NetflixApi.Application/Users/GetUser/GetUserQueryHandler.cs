using NetflixApi.Application.Abstractions.Messaging;
using NetflixApi.Domain.Abstractions;
using NetflixApi.Domain.Users;

namespace NetflixApi.Application.Users.GetUser;

internal sealed class GetUserQueryHandler : IQueryHandler<GetUserQuery, UserResponse>
{
    private readonly IUserRepository _userRepository;

    public GetUserQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result<UserResponse>> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var result = await _userRepository.GetByIdAsync(request.UserId, cancellationToken);

        if (result != null)
        {
            var response = new UserResponse(
            result.Id,
            result.Name.Value,
            result.AvatarId.Value,
            result.ImageUrl.Value);

            return response;
        }
        else
        {
            return Result.Failure<UserResponse>(UserErrors.NotFound);
        }
    }
}
