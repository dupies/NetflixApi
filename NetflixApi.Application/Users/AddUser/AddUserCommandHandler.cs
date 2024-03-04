using NetflixApi.Application.Abstractions.Messaging;
using NetflixApi.Domain.Abstractions;
using NetflixApi.Domain.Users;
using Serilog;

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
        Log.Information("Adding user with Id {Id}", command.request.Id);
        
        var result = await _userRepository.GetByIdAsync(command.request.Id);

        if (result == null)
        {
            var user = new User(
            command.request.Id,
            command.request.Name,
            command.request.AvatarId,
            command.request.ImageUrl
            );

            await _userRepository.Add(user);
            Log.Information("User added with Id {Id}", command.request.Id);

            return user.Id;
        }
        else
        {
            Log.Information("User with Id {Id} already exists", command.request.Id);
            return Result.Failure<int>(UserErrors.AllreadyExists);
        }
    }
}
