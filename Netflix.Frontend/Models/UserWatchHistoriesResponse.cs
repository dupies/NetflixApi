namespace Netflix.Frontend.Models;
public record UserWatchHistoriesResponse(
    int UserId,
    int ShowId,
    ShowType Type,
    MovieResponse? Movie,
    TVShowResponse? TVShow
    );