namespace NetflixApi.Application.Users.AddUser;

public record AddUserRequest(
    int Id,
    string Name,
    string AvatarId,
    string ImageUrl);