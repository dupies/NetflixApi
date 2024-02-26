using NetflixApi.Application.Abstractions.Messaging;

namespace NetflixApi.Application.Users.GetUser;

public sealed record GetUserQuery(int UserId) : IQuery<UserResponse>;