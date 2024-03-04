namespace Netflix.Frontend.Models;
public record UserResponse(
    int Id,
    string Name,
    string AvatarId,
    string ImageUrl,
    List<int> FavouriteMovie,
    List<int> FavouriteTVShow);
