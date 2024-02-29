using NetflixApi.Domain.WatchHistories;

namespace NetflixApi.Application.Users.GetUser;
public record UserResponse(
    int Id,
    string Name,
    string AvatarId,
    string ImageUrl,
    ICollection<WatchHistory> WatchHistories);
