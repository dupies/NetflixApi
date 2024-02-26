using NetflixApi.Application.Abstractions.Messaging;
using NetflixApi.Domain.Abstractions;
using NetflixApi.Domain.Users;

namespace NetflixApi.Application.Users.AddUser;

internal sealed class AddUserCommandHandler : ICommandHandler<AddUserCommand, int>
{
    private readonly IUserRepository _userRepository;

    public AddUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result<int>> Handle(AddUserCommand command, CancellationToken cancellationToken)
    {
        var user = new User(
            command.request.Id,
            command.request.Name,
            command.request.AvatarId,
            command.request.ImageUrl
            );

        await _userRepository.Add( user );

        return user.Id;
    }
}
