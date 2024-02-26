using NetflixApi.Application.Abstractions.Messaging;

namespace NetflixApi.Application.Users.AddUser;

public record AddUserCommand(AddUserRequest request) :ICommand<int>;